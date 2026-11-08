import math
import matplotlib.pyplot as plt
import numpy as np
from matplotlib.lines import Line2D

# Лабораторная работа 2.3, вариант 9
# Метод сопряжённых градиентов (Флетчера-Ривса)

# Параметры функции из табл. 2.2 (вариант 9)
a = 2.0
b = -2.0
c = 3.0
d = 4.0
alpha = math.radians(20)

e = 1e-5          # критерий останова: |grad f(X)| <= e
dx = 1e-8         # приращение для разностной производной
e_line = 1e-10    # точность одномерного поиска
delta = 0.01      # начальный шаг процедуры локализации
max_iter = 50000
restart = True    # обновлять направление антиградиентом каждые n итераций


def f_ellipse(x):
    x1, x2 = x[0], x[1]
    u = (x1 - a) * np.cos(alpha) + (x2 - b) * np.sin(alpha)
    v = (x2 - b) * np.cos(alpha) - (x1 - a) * np.sin(alpha)
    return u**2 / c**2 + v**2 / d**2


def f_rosenbrock(x):
    x1, x2 = x[0], x[1]
    return 100 * (x2 - x1**2)**2 + (1 - x1)**2


def gradient(f, x):
    """Частные производные по разностной схеме: (f(x + dx*e_i) - f(x)) / dx."""
    f0 = f(x)
    g = np.zeros(len(x))
    for i in range(len(x)):
        x_dx = x.copy()
        x_dx[i] += dx
        g[i] = (f(x_dx) - f0) / dx
    return g


def localize(phi, t0, step):
    """Поиск отрезка, содержащего минимум phi(t), с удвоением шага (из ЛР 2.2)."""
    y1, y2 = t0, t0 + step
    f1, f2 = phi(y1), phi(y2)

    if f2 >= f1:
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
    """h = argmin f(x + h*s). Направление нормируется, чтобы шаг δ имел смысл длины."""
    s_unit = s / np.linalg.norm(s)
    phi = lambda t: f(x + t * s_unit)
    left, right = localize(phi, 0.0, delta)
    t = golden_section(phi, left, right, e_line)
    h = t / np.linalg.norm(s)           # тот же шаг в масштабе исходного S
    return x + t * s_unit, h


def conjugate_gradients(f, x0):
    x = np.array(x0, dtype=float)
    n = len(x)
    # История: (X(k), f(X(k)), |grad|, h(k), beta(k-1))
    history = []

    g = gradient(f, x)
    s = -g                      # S0 = -grad f(X0)
    beta = None

    for k in range(max_iter):
        g_norm = np.linalg.norm(g)

        # Критерий останова (2.3)
        if g_norm <= e:
            history.append((x.copy(), f(x), g_norm, None, beta))
            break

        # Если S не направление убывания - начинаем заново с антиградиента
        if np.dot(s, g) >= 0:
            s = -g

        x_new, h = line_search(f, x, s)
        history.append((x.copy(), f(x), g_norm, h, beta))

        g_new = gradient(f, x_new)

        # Коэффициент beta по формуле (2.7): |grad f(X(k+1))|^2 / |grad f(X(k))|^2
        if restart and (k + 1) % n == 0:
            beta = 0.0
        else:
            beta = np.dot(g_new, g_new) / np.dot(g, g)

        # Новое сопряжённое направление
        s = -g_new + beta * s
        x, g = x_new, g_new
    else:
        history.append((x.copy(), f(x), np.linalg.norm(gradient(f, x)), None, beta))

    return x, history


def print_history(name, x0, x_min, history, f):
    print(f"\n=== {name}, X0 = ({x0[0]}, {x0[1]}) ===")
    print(f"{'k':>6} | {'X(k)':^26} | {'f(X(k))':>12} | {'|grad f|':>10} | {'h(k)':>10} | {'beta(k-1)':>10}")
    print("-" * 91)
    for k, (xk, fk, gk, hk, bk) in enumerate(history):
        # Для длинных историй выводим начало и конец
        if len(history) > 40 and 20 <= k < len(history) - 10:
            if k == 20:
                print(f"{'...':>6} | {'...':^26} |")
            continue
        h_str = f"{hk:10.3e}" if hk is not None else f"{'-':>10}"
        b_str = f"{bk:10.4f}" if bk is not None else f"{'-':>10}"
        print(f"{k:>6} | ({xk[0]:10.6f}, {xk[1]:10.6f}) | {fk:12.4e} | {gk:10.3e} | {h_str} | {b_str}")
    print(f"Итераций: {len(history) - 1}")
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
        x_min, history = conjugate_gradients(f, x0)
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

    pts = np.array([h[0] for h in history])
    ax.plot(pts[:, 0], pts[:, 1], color="red", linewidth=1.2, marker="o", markersize=2.5)

    ax.scatter([x0[0]], [x0[1]], color="black", s=60, zorder=5)
    ax.annotate("$X^0$", x0, textcoords="offset points", xytext=(6, 6))
    ax.scatter([x_exact[0]], [x_exact[1]], color="gold", edgecolor="black", marker="*", s=200, zorder=6)

    ax.set_title(f"{name}, $X^0$ = {x0}\nитераций: {len(history) - 1}, "
                 f"$X^*$ = ({x_min[0]:.4f}, {x_min[1]:.4f})", fontsize=10)
    ax.set_xlabel("$x_1$")
    ax.set_ylabel("$x_2$")
    ax.set_aspect("equal", adjustable="box")
    ax.grid(True, linestyle=":", alpha=0.5)

legend_elements = [
    Line2D([0], [0], color="red", lw=1.5, marker="o", markersize=4, label="Шаги вдоль сопряжённых направлений $X^k \\to X^{k+1}$"),
    Line2D([0], [0], marker="*", color="w", markerfacecolor="gold", markeredgecolor="black",
           markersize=14, label="Точный минимум $X^*$"),
]
fig.legend(handles=legend_elements, loc="lower center", ncol=2)
fig.suptitle("Метод сопряжённых градиентов (Флетчера–Ривса)", fontsize=13)

plt.tight_layout(rect=(0, 0.04, 1, 1))
plt.show()
