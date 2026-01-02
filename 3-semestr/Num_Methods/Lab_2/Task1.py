import numpy as np

# 1. Задаем исходные данные на основе ваших файлов
A = np.array([
    [0.43,  0.045, -0.02,  0.03, -0.02],
    [0.12,  0.377,  0.02,  0.0,   -0.01],
    [0.01,  0.032,  0.356, -0.02,  0.05],
    [0.12, -0.11,   0.0,    0.49,  0.112],
    [-0.05, 0.0,    0.025, -0.01,  0.294]
])

b = np.array([2.56, 2.77, -0.916, 0.808, -0.639])

def haletsky_solver(A, b):
    n = len(A)
    L = np.zeros((n, n))
    U = np.eye(n) # Матрица U с единицами на диагонали

    # --- ЭТАП 1: Разложение A = LU (формулы 3.11 и 3.12) ---
    for i in range(n):
        # Вычисляем элементы L для i-го столбца
        for j in range(i, n):
            sum_l = sum(L[j][k] * U[k][i] for k in range(i))
            L[j][i] = A[j][i] - sum_l
        
        # Вычисляем элементы U для i-й строки
        for j in range(i + 1, n):
            sum_u = sum(L[i][k] * U[k][j] for k in range(i))
            U[i][j] = (A[i][j] - sum_u) / L[i][i]

    # --- ЭТАП 2: Прямой ход Ly = b (формула 3.14) ---
    y = np.zeros(n)
    for i in range(n):
        sum_y = sum(L[i][k] * y[k] for k in range(i))
        y[i] = (b[i] - sum_y) / L[i][i]

    # --- ЭТАП 3: Обратный ход Ux = y (формула 3.15) ---
    x = np.zeros(n)
    for i in range(n - 1, -1, -1):
        sum_x = sum(U[i][k] * x[k] for k in range(i + 1, n))
        x[i] = y[i] - sum_x
    
    return L, U, y, x

# Решаем
L, U, y, x = haletsky_solver(A, b)

# Вычисляем вектор невязки r = Ax - b
residual = np.dot(A, x) - b

# Вывод результатов
np.set_printoptions(precision=4, suppress=True)
print("Матрица L:\n", L)
print("\nМатрица U:\n", U)
print("\nПромежуточный вектор y:", y)
print("\nИскомый вектор x (ответ):", x)
print("\nВектор невязки (r):", residual)