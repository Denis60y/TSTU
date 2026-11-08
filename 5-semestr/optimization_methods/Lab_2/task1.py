import math
import matplotlib.pyplot as plt
import numpy as np
from matplotlib.lines import Line2D

# Лабораторная работа 2.2, вариант 9
# Модифицированный метод покоординатного спуска (метод Пауэлла)

# Параметры функции из табл. 2.2 (вариант 9)
a = 2.0
b = -2.0
c = 3.0
d = 4.0
alpha = math.radians(20)

e = 1e-7          # точность для критерия останова |X(k+1) - X(k)| <= e
e_line = 1e-9     # точность одномерного поиска
delta = 0.1       # начальный шаг процедуры локализации
max_iter = 5000


def f_ellipse(x):
    x1, x2 = x[0], x[1]
    u = (x1 - a) * np.cos(alpha) + (x2 - b) * np.sin(alpha)
    v = (x2 - b) * np.cos(alpha) - (x1 - a) * np.sin(alpha)
    return u**2 / c**2 + v**2 / d**2


def f_rosenbrock(x):
    x1, x2 = x[0], x[1]
    return 100 * (x2 - x1**2)**2 + (1 - x1)**2


def localize(phi, t0, step):
    """Поиск отрезка, содержащего минимум phi(t), с удвоением шага."""
    y1, y2 = t0, t0 + step
    f1, f2 = phi(y1), phi(y2)

    if f2 >= f1:
        # В положительном направлении функция не убывает - пробуем обратное
        y_back = t0 - step
        f_back = phi(y_back)
        if f_back >= f1:
            return y_back, y2
        step = -step
        y2, f2 = y_back, f_back

    y_prev = y1
    while True:
        step *= 2
        y_next = y2 + step
        f_next = phi(y_next)
        if f_next >= f2:
            return min(y_prev, y_next), max(y_prev, y_next)
        y_prev, y2, f2 = y2, y_next, f_next


def golden_section(phi, a0, b0, eps):
    """Метод золотого сечения (из лабораторной работы 1)."""
    y = (3 - math.sqrt(5)) / 2
    x1 = a0 + y * (b0 - a0)
    x2 = b0 - y * (b0 - a0)
    f1, f2 = phi(x1), phi(x2)

    while (b0 - a0) >= eps:
        if f1 < f2:
            b0, x2, f2 = x2, x1, f1
            x1 = a0 + y * (b0 - a0)
            f1 = phi(x1)
        else:
            a0, x1, f1 = x1, x2, f2
            x2 = b0 - y * (b0 - a0)
            f2 = phi(x2)

    return (a0 + b0) / 2


def line_search(f, x, s):
    """h = argmin f(x + h*s): локализация отрезка + золотое сечение."""
    phi = lambda h: f(x + h * s)
    left, right = localize(phi, 0.0, delta)
    h = golden_section(phi, left, right, e_line)
    return x + h * s


def powell(f, x0):
    x = np.array(x0, dtype=float)
    n = len(x)
    # История: (X(k), X~(k), X(k+1))
    history = []

    for k in range(max_iter):
        # 1. Спуск вдоль координатных осей (Гаусс-Зейдель)
        x_tilde = x.copy()
        coord_path = [x_tilde.copy()]
        for i in range(n):
            ei = np.zeros(n)
            ei[i] = 1.0
            x_tilde = line_search(f, x_tilde, ei)
            coord_path.append(x_tilde.copy())

        # 2. Поиск вдоль направления S = X~(k) - X(k)
        s = x_tilde - x
        if np.linalg.norm(s) > 1e-12:
            x_new = line_search(f, x, s)
            # Если поиск по S оказался хуже покоординатного - берём X~
            if f(x_new) > f(x_tilde):
                x_new = x_tilde
        else:
            x_new = x_tilde

        history.append((x.copy(), coord_path, x_new.copy()))

        if np.linalg.norm(x_new - x) <= e:
            x = x_new
            break
        x = x_new

    return x, history


def print_history(name, x0, x_min, history, f):
    print(f"\n=== {name}, X0 = ({x0[0]}, {x0[1]}) ===")
    print(f"{'k':>4} | {'X(k)':^24} | {'X~(k)':^24} | {'X(k+1)':^24} | {'f(X(k+1))':>12}")
    print("-" * 100)
    for k, (xk, path, xk1) in enumerate(history):
        # Для длинных историй выводим начало и конец
        if len(history) > 40 and 20 <= k < len(history) - 10:
            if k == 20:
                print(f"{'...':>4} | {'...':^24} | {'...':^24} | {'...':^24} |")
            continue
        xt = path[-1]
        print(f"{k:>4} | ({xk[0]:9.5f}, {xk[1]:9.5f}) | ({xt[0]:9.5f}, {xt[1]:9.5f}) | "
              f"({xk1[0]:9.5f}, {xk1[1]:9.5f}) | {f(xk1):12.3e}")
    print(f"Итераций: {len(history)}")
    print(f"X* = ({x_min[0]:.6f}, {x_min[1]:.6f}),  f(X*) = {f(x_min):.3e}")


tasks = [
    ("Эллиптический параболоид", f_ellipse, [(-4.0, 4.0), (7.0, 3.0)], (a, b),
     (-6, 9, -7, 6), None),
    ("Функция Розенброка", f_rosenbrock, [(-1.2, 1.0), (2.0, -1.0)], (1.0, 1.0),
     (-2, 2.5, -1.5, 3), np.logspace(-2, 3.5, 20)),
]

results = []
for name, f, starts, x_exact, box, levels in tasks:
    for x0 in starts:
        x_min, history = powell(f, x0)
        print_history(name, x0, x_min, history, f)
        results.append((name, f, x0, x_min, history, x_exact, box, levels))

# --- Визуализация ---
fig, axes = plt.subplots(2, 2, figsize=(13, 11))

for ax, (name, f, x0, x_min, history, x_exact, box, levels) in zip(axes.flat, results):
    X1, X2 = np.meshgrid(np.linspace(box[0], box[1], 400), np.linspace(box[2], box[3], 400))
    Z = f((X1, X2))
    cs = ax.contour(X1, X2, Z, levels=levels if levels is not None else 15,
                    cmap="viridis", linewidths=0.8)
    ax.clabel(cs, fontsize=7, fmt="%.3g")

    for xk, path, xk1 in history:
        path = np.array(path)
        # Покоординатный спуск: X(k) -> X~(k)
        ax.plot(path[:, 0], path[:, 1], color="#1f77b4", linewidth=1.2)
        # Поиск вдоль направления S: X(k) -> X(k+1)
        ax.plot([xk[0], xk1[0]], [xk[1], xk1[1]], color="red", linestyle="--", linewidth=1.2)
        ax.scatter([xk1[0]], [xk1[1]], color="red", s=12, zorder=4)

    ax.scatter([x0[0]], [x0[1]], color="black", s=60, zorder=5)
    ax.annotate("$X^0$", x0, textcoords="offset points", xytext=(6, 6))
    ax.scatter([x_exact[0]], [x_exact[1]], color="gold", edgecolor="black", marker="*", s=200, zorder=6)

    ax.set_title(f"{name}, $X^0$ = {x0}\nитераций: {len(history)}, "
                 f"$X^*$ = ({x_min[0]:.4f}, {x_min[1]:.4f})", fontsize=10)
    ax.set_xlabel("$x_1$")
    ax.set_ylabel("$x_2$")
    ax.set_aspect("equal", adjustable="box")
    ax.grid(True, linestyle=":", alpha=0.5)

legend_elements = [
    Line2D([0], [0], color="#1f77b4", lw=1.5, label="Спуск по осям $X^k \\to \\tilde{X}^k$"),
    Line2D([0], [0], color="red", lw=1.5, linestyle="--", label="Поиск вдоль $S^k$: $X^k \\to X^{k+1}$"),
    Line2D([0], [0], marker="*", color="w", markerfacecolor="gold", markeredgecolor="black",
           markersize=14, label="Точный минимум $X^*$"),
]
fig.legend(handles=legend_elements, loc="lower center", ncol=3)
fig.suptitle("Метод Пауэлла (модифицированный покоординатный спуск)", fontsize=13)

plt.tight_layout(rect=(0, 0.04, 1, 1))
plt.show()
