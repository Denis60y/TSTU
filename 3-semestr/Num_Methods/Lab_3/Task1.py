import numpy as np

# 1. Исходные данные (Вариант 17)
x_nodes = np.array([1.50, 1.55, 1.60, 1.65, 1.70, 1.75, 1.80, 1.85, 1.90, 1.95, 2.00, 2.05, 2.10])
y_nodes = np.array([15.132, 17.422, 20.393, 23.994, 28.160, 32.812, 37.857, 43.189, 48.689, 54.225, 59.653, 64.817, 69.550])

n = len(x_nodes) - 1 # Степень многочлена (n=12)
h = x_nodes[1] - x_nodes[0]

# 2. Построение таблицы конечных разностей (как в разделе 5.2)
diff_table = np.zeros((n + 1, n + 1))
diff_table[:, 0] = y_nodes
for j in range(1, n + 1):
    for i in range(n + 1 - j):
        diff_table[i][j] = diff_table[i+1][j-1] - diff_table[i][j-1]

# 3. Вычисление 4-х точек x (m=4), подставляем n=12 в формулы задания
target_x = [
    1.60 + 0.006 * n,
    1.83 + 0.003 * n,
    1.725 + 0.002 * n,
    2.00 - 0.013 * n
]

def calculate_Pn(x):
    q = (x - x_nodes[0]) / h
    res = diff_table[0, 0] # Стартовое y0
    q_prod = 1
    fact = 1
    # Цикл по формуле 5.1
    for i in range(1, n + 1):
        q_prod *= (q - i + 1)
        fact *= i
        res += (q_prod * diff_table[0, i]) / fact
    return res

# 4. Вывод в консоль в виде текстовой таблицы
print("Результаты интерполирования (Первая формула Ньютона, n=12):")
print("-" * 45)
print(f"| {'j':^3} | {'xj':^10} | {'Pn(xj)':^20} |")
print("-" * 45)

for j, xj in enumerate(target_x, 1):
    pn_xj = calculate_Pn(xj)
    # Выводим индекс, x и результат Pn(x)
    print(f"| {j:^3} | {xj:^10.4f} | {pn_xj:^20.6f} |")

print("-" * 45)