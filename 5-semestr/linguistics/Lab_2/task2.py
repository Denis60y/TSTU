from dataclasses import dataclass

dick = {"if": 1, "THEN": 2, "*": 3, "MOD": 4, "DIY": 5, "=": 6, ":=": 7, ";": 8, "peremen": 9, "const": 10}
peremen = {"i": 1, "Z": 2, "X": 3}
const = {"2": 1, "0": 2}

# Грамматика языка:
#   программа  -> оператор [;]
#   оператор   -> условный | присваивание
#   условный   -> if условие THEN оператор
#   условие    -> выражение = выражение
#   присваивание -> переменная := выражение
#   выражение  -> операнд { (* | MOD | DIY) операнд }
#   операнд    -> переменная | константа


# ---------------- Внутреннее представление (дерево) ----------------
# Каждый узел дерева отвечает на вопросы "что делаем?" и "над чем?":
#   Compare(op, left, right)  - СРАВНИТЬ left с right операцией op
#   Assign(target, value)     - ПРИСВОИТЬ в target значение value
#   If(condition, body)       - ЕСЛИ condition истинно, ТО выполнить body
#   BinOp(op, left, right)    - ВЫЧИСЛИТЬ left op right
#   Var / Const               - листья: переменная / число

class Node:
    pass


@dataclass
class Var(Node):
    name: str


@dataclass
class Const(Node):
    value: int


@dataclass
class BinOp(Node):
    op: str
    left: Node
    right: Node


@dataclass
class Compare(Node):
    op: str
    left: Node
    right: Node


@dataclass
class Assign(Node):
    target: Var
    value: Node


@dataclass
class If(Node):
    condition: Node
    body: Node


@dataclass
class Program(Node):
    body: Node


def to_str(node) -> str:
    """Компактная скобочная запись дерева, например (if (= (MOD i 2) 0) (:= Z (* Z X)))"""
    if isinstance(node, Program):
        return to_str(node.body)
    if isinstance(node, If):
        return f"(if {to_str(node.condition)} {to_str(node.body)})"
    if isinstance(node, Compare):
        return f"({node.op} {to_str(node.left)} {to_str(node.right)})"
    if isinstance(node, Assign):
        return f"(:= {to_str(node.target)} {to_str(node.value)})"
    if isinstance(node, BinOp):
        return f"({node.op} {to_str(node.left)} {to_str(node.right)})"
    if isinstance(node, Var):
        return node.name
    if isinstance(node, Const):
        return str(node.value)


# ---------------- Лексический анализатор ----------------

def make_token(text):
    """Создаёт лексему (код, текст, отображение) для известного текста."""
    if text in dick:
        return (dick[text], text, str(dick[text]))
    if text in peremen:
        return (9, text, f"9:{peremen[text]}")
    if text in const:
        return (10, text, f"10:{const[text]}")
    return None


def lexer(string: str) -> list:
    """Возвращает список лексем вида (код, текст, отображение)"""
    tokens = []
    string = string.replace(";", " ; ")

    for word in string.split():
        tok = make_token(word)
        if tok:
            tokens.append(tok)
            continue

        # слово склеено (например Z:=Z*X): режем по символам
        i = 0
        while i < len(word):
            tok = make_token(word[i:i + 2]) if word[i:i + 2] in dick else None
            if tok:
                tokens.append(tok)
                i += 2
                continue

            tok = make_token(word[i])
            if tok:
                tokens.append(tok)
                i += 1
            else:
                raise SyntaxError(f"неизвестный символ '{word[i]}'")

    return tokens


# ---------------- Синтаксический анализатор ----------------
# Каждая функция разбора теперь не только проверяет синтаксис,
# но и ВОЗВРАЩАЕТ узел дерева для разобранной части строки.

tokens = []
pos = 0


def log(d, text):
    """Печать шага разбора с отступом: чем глубже правило, тем больше отступ"""
    print("    " * d + text)


def current():
    """Текущая лексема (или пометка о конце строки)"""
    if pos < len(tokens):
        return tokens[pos]
    return (0, "конец строки", "0")


def eat(code, name, d) -> str:
    """Проверить, что текущая лексема нужного типа, перейти к следующей и вернуть её текст"""
    global pos
    if current()[0] == code:
        text = current()[1]
        log(d, f"[+] {name}: '{text}'")
        pos += 1
        return text
    raise SyntaxError(f"ожидалось {name}, а встретилось '{current()[1]}'")


def program(d=0) -> Program:
    """программа -> оператор [;]"""
    log(d, "<программа>")
    body = statement(d + 1)
    if current()[0] == 8:
        eat(8, "';'", d + 1)
    if pos < len(tokens):
        raise SyntaxError(f"лишнее в конце: '{current()[1]}'")
    return Program(body)


def statement(d) -> Node:
    """оператор -> условный | присваивание"""
    log(d, "<оператор>")
    if current()[0] == 1:
        return if_statement(d + 1)
    if current()[0] == 9:
        return assignment(d + 1)
    raise SyntaxError(f"ожидался оператор, а встретилось '{current()[1]}'")


def if_statement(d) -> If:
    """условный -> if условие THEN оператор"""
    log(d, "<условный>")
    eat(1, "'if'", d + 1)
    cond = condition(d + 1)
    eat(2, "'THEN'", d + 1)
    body = statement(d + 1)
    return If(cond, body)


def condition(d) -> Compare:
    """условие -> выражение = выражение"""
    log(d, "<условие>")
    left = expression(d + 1)
    op = eat(6, "'='", d + 1)
    right = expression(d + 1)
    return Compare(op, left, right)


def assignment(d) -> Assign:
    """присваивание -> переменная := выражение"""
    log(d, "<присваивание>")
    name = eat(9, "переменная", d + 1)
    eat(7, "':='", d + 1)
    value = expression(d + 1)
    return Assign(Var(name), value)


def expression(d) -> Node:
    """выражение -> операнд { (* | MOD | DIY) операнд }
    Операции выполняются слева направо: X*X*X -> ((X*X)*X)"""
    log(d, "<выражение>")
    left = operand(d + 1)
    while current()[0] in (3, 4, 5):
        op = eat(current()[0], "операция", d + 1)
        right = operand(d + 1)
        left = BinOp(op, left, right)
    return left


def operand(d) -> Node:
    """операнд -> переменная | константа"""
    if current()[0] == 9:
        return Var(eat(9, "переменная", d))
    if current()[0] == 10:
        return Const(int(eat(10, "константа", d)))
    raise SyntaxError(f"ожидалась переменная или константа, а встретилось '{current()[1]}'")


def analiz(string: str) -> str:
    """Запускает лексический, потом синтаксический анализ и печатает дерево"""
    global tokens, pos
    print("=" * 50)
    print(f"Строка:   {string}")
    try:
        tokens = lexer(string)
        print("Лексемы:  " + "  ".join(f"{t[1]}({t[2]})" for t in tokens))
        print("Разбор:")
        pos = 0
        tree = program()
        print("\nСкобочная запись:  " + to_str(tree))
        return "OK, строка синтаксически верна"
    except SyntaxError as e:
        return f"ОШИБКА: {e}"


tests = [
    "if i MOD 2=0 THEN Z:=Z*X;",
    "i:=i DIY 2;",
    "X:=X*X*X",
]

for t in tests:
    print(f"Результат: {analiz(t)}")
    print()
    