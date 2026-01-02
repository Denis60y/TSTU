import numpy as np
import matplotlib.pyplot as plt

# -------------------------------
# Правая часть ОДУ
# -------------------------------
def f(x, y):
    return np.sin(x + 1) * np.exp(-4 * x - 4) + np.sin(x + 1) * y


# -------------------------------
# Метод Рунге–Кутта 2-го порядка
# (метод средней точки)
# -------------------------------
def rk2_step(x, y, h):
    k1 = h * f(x, y)
    k2 = h * f(x + h / 2, y + k1 / 2)
    return y + k2


# -------------------------------
# АВТОМАТИЧЕСКИЙ ШАГ (по Рунге)
# -------------------------------
x0, y0 = -1.0, 8.0
b = 2 * np.pi - 1

h = 0.5
eps = 1e-3
r = 2   # порядок метода RK2

Xa = [x0]
Ya = [y0]

x = x0
y = y0

while x < b - 1e-12:

    if x + h > b:
        h = b - x

    while True:
        # шаг h
        y_h = rk2_step(x, y, h)

        # два шага h/2
        h2 = h / 2
        y_mid = rk2_step(x, y, h2)
        y_h2 = rk2_step(x + h2, y_mid, h2)

        # формула Рунге
        delta = abs(y_h - y_h2) / (2**r - 1)

        if delta > eps:
            h /= 2
        else:
            break

    # шаг принят
    x += h
    y = y_h2

    Xa.append(x)
    Ya.append(y)

    # попытка увеличить шаг
    if delta < eps / 4:
        h *= 2


# -------------------------------
# ПОСТОЯННЫЙ ШАГ
# -------------------------------
N = len(Xa) - 1
h_const = (b - x0) / N

Xc = [x0]
Yc = [y0]

x = x0
y = y0

for _ in range(N):
    y = rk2_step(x, y, h_const)
    x += h_const
    Xc.append(x)
    Yc.append(y)


print(f"Количество шагов N = {N}")

print("\nТаблица значений (автоматический шаг):")
for i, (x, y) in enumerate(zip(Xa, Ya)):
    print(f"{i}: x={x:.4f}, y={y:.4f}")

print("\nТаблица значений (постоянный шаг):")
for i, (x, y) in enumerate(zip(Xc, Yc)):
    print(f"{i}: x={x:.4f}, y={y:.4f}")


# -------------------------------
# ГРАФИКИ
# -------------------------------
plt.figure(figsize=(10, 5))
plt.plot(Xa, Ya, 'r-o', markersize=3, label='RK2 с автоматическим шагом')
plt.plot(Xc, Yc, 'b--s', markersize=3, label='RK2 с постоянным шагом')

plt.xlabel('x')
plt.ylabel('y')
plt.title('Метод Рунге–Кутта 2-го порядка\nСравнение автоматического и постоянного шага')
plt.legend()
plt.grid()
plt.show()