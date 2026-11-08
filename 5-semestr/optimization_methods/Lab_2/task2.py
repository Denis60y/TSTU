import math
import matplotlib.pyplot as plt
import numpy as np
from matplotlib.lines import Line2D
from matplotlib.patches import Polygon

# Лабораторная работа 2.2, вариант 9
# Симплексный метод (Нелдера-Мида)

# Параметры функции из табл. 2.2 (вариант 9)
a = 2.0
b = -2.0
c = 3.0
d = 4.0
alpha_deg = 20
alpha_rad = math.radians(alpha_deg)

# Коэффициенты отражения, растяжения и сжатия
k_refl = 1.0
k_expand = 2.0
k_contract = 0.5

e = 1e-10         # критерий останова: sigma < e
step = 1.0        # длина ребра начального симплекса
max_iter = 5000


def f_ellipse(x):
    x1, x2 = x[0], x[1]
    u = (x1 - a) * np.cos(alpha_rad) + (x2 - b) * np.sin(alpha_rad)
    v = (x2 - b) * np.cos(alpha_rad) - (x1 - a) * np.sin(alpha_rad)
    return u**2 / c**2 + v**2 / d**2


def f_rosenbrock(x):
    x1, x2 = x[0], x[1]
    return 100 * (x2 - x1**2)**2 + (1 - x1)**2


def simplex_method(f, x1):
    n = len(x1)
    # Начальный симплекс: X2 = X1 + k*E1, X3 = X2 + k*E2, ...
    X = [np.array(x1, dtype=float)]
    for j in range(n):
        ej = np.zeros(n)
        ej[j] = 1.0
        X.append(X[-1] + step * ej)
    X = np.array(X)
    F = np.array([f(x) for x in X])

    # История: (вершины симплекса, выполненная операция)
    history = [(X.copy(), "начальный симплекс")]

    for it in range(max_iter):
        # Шаг 3: наибольшее (h), следующее за ним (g) и наименьшее (l) значения
        order = np.argsort(F)
        l, g, h = order[0], order[-2], order[-1]

        # Шаг 4: центр тяжести всех вершин, кроме Xh
        xc = (X.sum(axis=0) - X[h]) / n

        # Шаг 5: отражение
        x0 = (1 + k_refl) * xc - k_refl * X[h]
        f0 = f(x0)

        if f0 < F[l]:
            # Шаг 6.1: растяжение
            xr = (1 - k_expand) * xc + k_expand * x0
            fr = f(xr)
            if fr < F[l]:
                X[h], F[h] = xr, fr
                op = "растяжение"
            else:
                X[h], F[h] = x0, f0
                op = "отражение"
        elif f0 <= F[g]:
            # Шаг 6.2: отражённая точка не самая плохая
            X[h], F[h] = x0, f0
            op = "отражение"
        else:
            # Шаг 7: сжатие
            if f0 < F[h]:
                xs = k_contract * x0 + (1 - k_contract) * xc
            else:
                xs = k_contract * X[h] + (1 - k_contract) * xc
            fs = f(xs)

            if fs < F[h]:
                # Шаг 8.1
                X[h], F[h] = xs, fs
                op = "сжатие"
            else:
                # Шаг 9: уменьшение размеров симплекса относительно Xl
                for i in range(n + 1):
                    if i != l:
                        X[i] = X[l] + 0.5 * (X[i] - X[l])
                        F[i] = f(X[i])
                op = "редукция"

        history.append((X.copy(), op))

        # Шаг 10: критерий останова
        f_mean = F.mean()
        sigma = math.sqrt(((F - f_mean)**2).sum() / (n + 1))
        if sigma < e:
            break

    best = X[np.argmin(F)]
    return best, history


def print_history(name, x0, x_min, history, f):
    print(f"\n=== {name}, X1 = ({x0[0]}, {x0[1]}) ===")
    print(f"{'k':>4} | {'операция':<18} | {'X1':^22} | {'X2':^22} | {'X3':^22} | {'f min':>10}")
    print("-" * 115)
    for k, (X, op) in enumerate(history):
        pts = " | ".join(f"({p[0]:8.4f}, {p[1]:8.4f})" for p in X)
        f_min = min(f(p) for p in X)
        print(f"{k:>4} | {op:<18} | {pts} | {f_min:10.3e}")

    ops = [op for _, op in history[1:]]
    print(f"Итераций: {len(ops)}  (отражений: {ops.count('отражение')}, растяжений: {ops.count('растяжение')}, "
          f"сжатий: {ops.count('сжатие')}, редукций: {ops.count('редукция')})")
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
        x_min, history = simplex_method(f, x0)
        print_history(name, x0, x_min, history, f)
        results.append((name, f, x0, x_min, history, x_exact, box, levels))

# --- Визуализация ---
op_colors = {
    "начальный симплекс": "black",
    "отражение": "#1f77b4",
    "растяжение": "#2ca02c",
    "сжатие": "orange",
    "редукция": "red",
}

fig, axes = plt.subplots(2, 2, figsize=(13, 11))

for ax, (name, f, x0, x_min, history, x_exact, box, levels) in zip(axes.flat, results):
    X1, X2 = np.meshgrid(np.linspace(box[0], box[1], 400), np.linspace(box[2], box[3], 400))
    Z = f((X1, X2))
    cs = ax.contour(X1, X2, Z, levels=levels if levels is not None else 15,
                    cmap="viridis", linewidths=0.8)
    ax.clabel(cs, fontsize=7, fmt="%.3g")

    # Симплексы, окрашенные по выполненной операции
    for X, op in history:
        ax.add_patch(Polygon(X, closed=True, fill=False, edgecolor=op_colors[op],
                             linewidth=1.5 if op == "начальный симплекс" else 0.7, alpha=0.8))

    # Траектория центров симплексов
    centers = np.array([X.mean(axis=0) for X, _ in history])
    ax.plot(centers[:, 0], centers[:, 1], color="gray", linewidth=0.8, alpha=0.7)

    ax.scatter([x0[0]], [x0[1]], color="black", s=60, zorder=5)
    ax.annotate("$X_1^0$", x0, textcoords="offset points", xytext=(6, 6))
    ax.scatter([x_exact[0]], [x_exact[1]], color="gold", edgecolor="black", marker="*", s=200, zorder=6)

    ax.set_title(f"{name}, $X_1^0$ = {x0}\nитераций: {len(history) - 1}, "
                 f"$X^*$ = ({x_min[0]:.4f}, {x_min[1]:.4f})", fontsize=10)
    ax.set_xlabel("$x_1$")
    ax.set_ylabel("$x_2$")
    ax.set_xlim(box[0], box[1])
    ax.set_ylim(box[2], box[3])
    ax.set_aspect("equal", adjustable="box")
    ax.grid(True, linestyle=":", alpha=0.5)

legend_elements = [Line2D([0], [0], color=col, lw=2, label=op) for op, col in op_colors.items()]
legend_elements.append(Line2D([0], [0], marker="*", color="w", markerfacecolor="gold",
                              markeredgecolor="black", markersize=14, label="точный минимум $X^*$"))
fig.legend(handles=legend_elements, loc="lower center", ncol=6)
fig.suptitle("Симплексный метод (Нелдера-Мида)", fontsize=13)

plt.tight_layout(rect=(0, 0.04, 1, 1))
plt.show()
