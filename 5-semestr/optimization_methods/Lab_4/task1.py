import numpy as np
import matplotlib.pyplot as plt
from matplotlib.lines import Line2D
from matplotlib.patches import Patch
from scipy.optimize import minimize

# ============================================================
# Лабораторная работа 2.4, вариант 9
# Метод внешней квадратичной функции штрафа
# Целевые функции:
# 1. Эллиптический параболоид
# 2. Функция Розенброка
# ============================================================

# ==========================================
# 1. ПАРАМЕТРЫ ВАРИАНТА 9 (Табл. 2.3)
# ==========================================
a = 1.0
b = -3.0
c = 1.0
d = 3.0
alpha = np.radians(85)

K1 = 1.0
C = 10.0
eps = 1e-4


# ==========================================
# 2. ЦЕЛЕВЫЕ ФУНКЦИИ
# ==========================================

def f0(x):
    """Целевая функция f0(X): эллиптический параболоид."""
    x1, x2 = x[0], x[1]
    u = (x1 - a) * np.cos(alpha) + (x2 - b) * np.sin(alpha)
    v = (x2 - b) * np.cos(alpha) - (x1 - a) * np.sin(alpha)
    return (u**2) / (c**2) + (v**2) / (d**2)


def f_rosenbrock(x):
    """Целевая функция Розенброка."""
    x1, x2 = x[0], x[1]
    return 100 * (x2 - x1**2)**2 + (1 - x1)**2


# ==========================================
# 3. ФУНКЦИИ ОГРАНИЧЕНИЙ
# ==========================================

def eval_constraints(x1, x2):
    """Вычисление f1(X) и f2(X)."""
    denom = np.where(np.abs(x2 + 2.0) < 1e-12, 1e-12, x2 + 2.0)

    # f1 >= 0
    f1 = -(x1 / np.exp(x2) + 1.0 / denom)

    # f2 >= 0
    f2 = x1

    return f1, f2


# ==========================================
# 4. ВНЕШНЯЯ КВАДРАТИЧНАЯ ФУНКЦИЯ ШТРАФА
# ==========================================

def R_exterior(x, K, f):
    """Вспомогательная функция с квадратичным штрафом."""

    f1, f2 = eval_constraints(x[0], x[1])

    p1 = min(0.0, f1)**2
    p2 = min(0.0, f2)**2

    return f(x) + K * (p1 + p2)


# ==========================================
# 5. АЛГОРИТМ ВНЕШНЕГО ШТРАФА
# ==========================================

def solve_exterior(x_start, f, function_name):

    x_curr = np.array(x_start, dtype=float)
    K = K1

    # Сохраняем стартовую точку и результаты
    # каждой внешней итерации
    history_points = [x_curr.copy()]
    history_K = []

    print("\n==========================================================================")
    print(
        f" МЕТОД ВНЕШНЕГО ШТРАФА: {function_name}, "
        f"X0 = ({x_start[0]}, {x_start[1]})"
    )
    print("==========================================================================")

    print(
        f"{'i':>4} | {'K':>10} | {'X_i*':^28} | "
        f"{'f(X_i*)':>12} | {'||X_i - X_{i-1}||':>16}"
    )

    print("-" * 76)

    iteration = 1

    while True:

        res = minimize(
            lambda x: R_exterior(x, K, f),
            x_curr,
            method='Nelder-Mead',
            options={
                'xatol': 1e-7,
                'fatol': 1e-7,
                'maxiter': 5000
            }
        )

        x_next = res.x
        diff = np.linalg.norm(x_next - x_curr)

        print(
            f"{iteration:>4} | {K:>10.2e} | "
            f"({x_next[0]:11.6f}, {x_next[1]:11.6f}) | "
            f"{f(x_next):12.6f} | {diff:16.6e}"
        )

        # Запоминаем результат текущей внешней итерации
        history_points.append(x_next.copy())
        history_K.append(K)

        if diff <= eps or iteration >= 25:
            break

        x_curr = x_next
        K *= C
        iteration += 1

    return x_next, np.array(history_points), np.array(history_K)


# ==========================================
# 6. РАСЧЕТ ДЛЯ ДВУХ ФУНКЦИЙ
# ==========================================

# Начальные точки эллиптического параболоида
# Оставлены из исходной программы.

ellipse_starts = [
    [0.01, -2.5],   # Внутри допустимой области
    [1.0, -1.0]     # Снаружи допустимой области
]

# Начальные точки функции Розенброка.
# Подобраны отдельно для этой целевой функции.

rosenbrock_starts = [
    [0.2, -2.2],    # Внутри допустимой области
    [0.2, -1.99]    # Снаружи допустимой области
]


# Параметры функций для расчета и визуализации

tasks = [

    (
        "Эллиптический параболоид",
        f0,
        (a, b),
        (-0.5, 3.0, -4.5, -0.8),
        None,
        ellipse_starts
    ),

    (
        "Функция Розенброка",
        f_rosenbrock,
        (1.0, 1.0),
        (-2.0, 2.5, -4.5, 3.0),
        np.logspace(-2, 3.5, 20),
        rosenbrock_starts
    )

]


results = []

for name, f, x_exact, box, levels, starts in tasks:

    for x0 in starts:

        x_min, history, k_history = solve_exterior(
            x0,
            f,
            name
        )

        results.append(
            (
                name,
                f,
                x0,
                x_min,
                history,
                x_exact,
                box,
                levels,
                k_history
            )
        )


# ==========================================
# 7. ВИЗУАЛИЗАЦИЯ
# Оформление как в лабораторной работе 2.3
# ==========================================

fig, axes = plt.subplots(2, 2, figsize=(13, 11))

for ax, (
    name, f, x0, x_min, history,
    x_exact, box, levels, k_history
) in zip(axes.flat, results):

    X1, X2 = np.meshgrid(
        np.linspace(box[0], box[1], 400),
        np.linspace(box[2], box[3], 400)
    )

    Z = f((X1, X2))

    # Линии уровня целевой функции
    cs = ax.contour(
        X1,
        X2,
        Z,
        levels=levels if levels is not None else 25,
        cmap="viridis",
        linewidths=0.8
    )

    ax.clabel(
        cs,
        fontsize=7,
        fmt="%.3g"
    )

    # Допустимая область
    F1, F2 = eval_constraints(X1, X2)

    feasible_mask = (
        (F1 >= 0) &
        (F2 >= 0) &
        (X2 < -2.0)
    )

    # Зеленая заливка допустимой области
    ax.contourf(
        X1,
        X2,
        feasible_mask.astype(float),
        levels=[0.5, 1.5],
        colors=['#bbf7d0'],
        alpha=0.5
    )

    # Граница допустимой области
    ax.contour(
        X1,
        X2,
        feasible_mask.astype(float),
        levels=[0.5],
        colors=['darkgreen'],
        linewidths=1.5
    )

    # Граница x2 = -2
    ax.axhline(
        -2.0,
        color='gray',
        linestyle='--',
        linewidth=1,
        label='Разрыв $x_2 = -2$'
    )

    # Траектория движения алгоритма
    pts = history

    ax.plot(
        pts[:, 0],
        pts[:, 1],
        color="red",
        linewidth=1.2,
        marker="o",
        markersize=2.5
    )

    # Результаты внешних итераций
    iteration_points = history[1:]

    if len(iteration_points) > 0:

        ax.scatter(
            iteration_points[:, 0],
            iteration_points[:, 1],
            c=np.arange(1, len(iteration_points) + 1),
            cmap="viridis",
            s=55,
            edgecolors="black",
            linewidths=0.5,
            zorder=6
        )

        # Подписи номера итерации и значения K
        for i, (point, k_value) in enumerate(
            zip(iteration_points, k_history),
            start=1
        ):

            ax.annotate(
                f"{i}\nK={k_value:g}",
                point,
                xytext=(7, 7),
                textcoords="offset points",
                fontsize=7,
                bbox=dict(
                    boxstyle="round,pad=0.2",
                    fc="white",
                    alpha=0.75,
                    ec="gray"
                ),
                zorder=7
            )

    # Начальная точка
    ax.scatter(
        [x0[0]],
        [x0[1]],
        color="black",
        s=60,
        zorder=8
    )

    ax.annotate(
        "$X^0$",
        x0,
        textcoords="offset points",
        xytext=(6, 6)
    )

    # Последняя найденная точка
    ax.scatter(
        [x_min[0]],
        [x_min[1]],
        color="red",
        edgecolor="black",
        marker="D",
        s=65,
        zorder=9
    )

    # Безусловный минимум
    ax.scatter(
        [x_exact[0]],
        [x_exact[1]],
        color="gold",
        edgecolor="black",
        marker="*",
        s=200,
        zorder=8
    )

    ax.set_title(
        f"{name}, $X^0$ = ({x0[0]}, {x0[1]})\n"
        f"итераций: {len(history) - 1}, "
        f"$X$ = ({x_min[0]:.4f}, {x_min[1]:.4f})",
        fontsize=10
    )

    ax.set_xlabel("$x_1$")
    ax.set_ylabel("$x_2$")

    ax.set_xlim(box[0], box[1])
    ax.set_ylim(box[2], box[3])

    ax.set_aspect("equal", adjustable="box")

    ax.grid(
        True,
        linestyle=":",
        alpha=0.5
    )


# ==========================================
# 8. ОБЩАЯ ЛЕГЕНДА
# ==========================================

legend_elements = [

    Patch(
        facecolor="#bbf7d0",
        edgecolor="darkgreen",
        alpha=0.5,
        label="Допустимая область"
    ),

    Line2D(
        [0], [0],
        color="red",
        lw=1.5,
        marker="o",
        markersize=4,
        label="Траектория внешних итераций"
    ),

    Line2D(
        [0], [0],
        marker="D",
        color="w",
        markerfacecolor="red",
        markeredgecolor="black",
        markersize=7,
        label="Найденное приближение"
    ),

    Line2D(
        [0], [0],
        marker="*",
        color="w",
        markerfacecolor="gold",
        markeredgecolor="black",
        markersize=14,
        label="Безусловный минимум функции"
    ),

    Line2D(
        [0], [0],
        color="gray",
        linestyle="--",
        lw=1,
        label="Разрыв $x_2=-2$"
    )

]

fig.legend(
    handles=legend_elements,
    loc="lower center",
    ncol=2,
    fontsize=8
)

fig.suptitle(
    "Метод внешней квадратичной функции штрафа (вариант 9)",
    fontsize=13
)

plt.tight_layout(rect=(0, 0.07, 1, 1))

plt.show()
