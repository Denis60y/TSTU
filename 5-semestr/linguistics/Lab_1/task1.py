dick = {"if": 1, "THEN": 2, "*": 3, "MOD": 4, "DIY": 5, "=": 6, ":=": 7, ";": 8, "peremen": 9, "const": 10}
peremen = {"i": 1, "Z": 2, "X": 3}
const = {"2": 1, "0": 2}

test1 = "if i MOD 2=0 THEN Z:=Z*X;"
test2 = "i:=i DIY 2;"
test3 = "X:=X*X*X"


def analiz(string: str) -> str:
    """Функция принимает строчку кода и разбивает её на лексемы
    и формирует из них закодированную строку"""

    result = ""

    for word in string.split():

        if word in dick:
            result += str(dick.get(word)) + " "

        elif word in peremen:
            result += "9:" + str(peremen.get(word)) + " "

        elif word in const:
            result += "10:" + str(const.get(word)) + " "

        else:
            i = 0
            while i < len(word):
                if i + 1 < len(word) and word[i] + word[i + 1] in dick:
                    result += str(dick.get(word[i] + word[i + 1])) + " "
                    i += 2

                elif word[i] in dick:
                    result += str(dick.get(word[i])) + " "
                    i += 1

                elif word[i] in peremen:
                    result += "9:" + str(peremen.get(word[i])) + " "
                    i += 1

                elif word[i] in const:
                    result += "10:" + str(const.get(word[i])) + " "
                    i += 1

                else:
                    i += 1

    return result


print(f"{test1} \t-> \t\t{analiz(test1)}")
print(f"{test2} \t\t\t\t-> \t\t{analiz(test2)}")
print(f"{test3} \t\t\t\t\t-> \t\t{analiz(test3)}")
