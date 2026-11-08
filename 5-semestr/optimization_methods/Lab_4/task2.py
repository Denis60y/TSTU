
import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import minimize
from matplotlib.lines import Line2D
from matplotlib.patches import Patch

# ==========================================
# Лабораторная работа 2.4, вариант 9
# Метод внутренней барьерной функции штрафа
# 1. Эллиптический параболоид
# 2. Функция Розенброка
# ==========================================

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
    """Вычисление f1(X) и f2(X) со скалярным и векторным режимами."""
    denom = np.where(np.abs(x2 + 2.0) < 1e-12, 1e-12, x2 + 2.0)

    f1 = -(x1 / np.exp(x2) + 1.0 / denom)
    f2 = x1

    return f1, f2


def is_strictly_feasible(x):
    if x[1] >= -2.0:
        return False

    f1, f2 = eval_constraints(x[0], x[1])

    return (f1 > 1e-6) and (f2 > 1e-6)


# ==========================================
# 4. БАРЬЕРНАЯ ФУНКЦИЯ (2.10)
# ==========================================

def R_interior(x, K, f):
    if not is_strictly_feasible(x):
        return 1e12  # Искусственная стенка барьера

    f1, f2 = eval_constraints(x[0], x[1])

    return f(x) + (1.0 / K) * (1.0 / f1 + 1.0 / f2)


# ==========================================
# 5. АЛГОРИТМ ВНУТРЕННЕГО БАРЬЕРА
# ==========================================

def solve_interior(x_start, f, function_name):
    x_curr = np.array(x_start, dtype=float)

    # Проверка начальной точки.
    # Если точка находится снаружи допустимой области,
    # метод не запускается.
    # Перемещения внутрь нет.

    if not is_strictly_feasible(x_curr):
        print("\n==========================================================================")
        print(f" МЕТОД ВНУТРЕННЕГО БАРЬЕРА: {function_name}")
        print(f" Начальная точка X0 = ({x_start[0]}, {x_start[1]}) находится вне допустимой области.")
        print(" Алгоритм остановлен. Количество итераций: 0.")
        print("==========================================================================")

        return None, np.array([x_curr]), np.array([])

    K = K1
    history = [x_curr.copy()]
    history_K = []

    print("\n==========================================================================")
    print(f" МЕТОД ВНУТРЕННЕГО БАРЬЕРА: {function_name}, старт из ({x_curr[0]:.6f}, {x_curr[1]:.6f})")
    print("==========================================================================")
    print(f"{'i':>4} | {'K':>10} | {'X_i*':^28} | {'f(X_i*)':>12} | {'||X_i - X_{i-1}||':>16}")
    print("-" * 76)

    iteration = 1

    while True:
        res = minimize(
            lambda x: R_interior(x, K, f),
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

        history.append(x_next.copy())
        history_K.append(K)

        if diff <= eps or iteration >= 25:
            break

        x_curr = x_next
        K *= C
        iteration += 1

    return x_next, np.array(history), np.array(history_K)


# ==========================================
# 6. РАСЧЕТ ДЛЯ ДВУХ ФУНКЦИЙ
# ==========================================

# Исходные начальные точки — без изменений

x0_in = [0.01, -2.5]   # Внутри области
x0_out = [1.0, -1.0]   # Снаружи области

starts = [x0_in, x0_out]


tasks = [
    (
        "Эллиптический параболоид",
        f0,
        (a, b),
        (-0.5, 3.0, -4.5, -0.8),
        None
    ),
    (
        "Функция Розенброка",
        f_rosenbrock,
        (1.0, 1.0),
        (-2.0, 2.5, -4.5, 3.0),
        np.logspace(-2, 3.5, 20)
    )
]


results = []

for name, f, x_exact, box, levels in tasks:

    for x0 in starts:
        sol, hist, k_hist = solve_interior(
            x0,
            f,
            name
        )

        results.append(
            (
                name,
                f,
                x0,
                sol,
                hist,
                x_exact,
                box,
                levels,
                k_hist
            )
        )


# ==========================================
# 7. ВИЗУАЛИЗАЦИЯ
# Стиль как в лабораторной работе 2.3
# ==========================================

fig, axes = plt.subplots(2, 2, figsize=(13, 11))

for ax, (
    name, f, x0, sol, hist,
    x_exact, box, levels, k_hist
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

    ax.clabel(cs, fontsize=7, fmt="%.3g")

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

    ax.axhline(
        -2.0,
        color='gray',
        linestyle='--',
        linewidth=1,
        label='Разрыв $x_2 = -2$'
    )

    # Траектория движения алгоритма.
    # Если начальная точка снаружи,
    # history содержит только X0 — движения нет.

    if len(hist) > 1:
        ax.plot(
            hist[:, 0],
            hist[:, 1],
            color='red',
            linestyle='-',
            linewidth=1.2,
            alpha=0.65,
            marker='o',
            markersize=2.5,
            label='Траектория итераций'
        )

    # Начальная точка
    ax.scatter(
        [x0[0]],
        [x0[1]],
        color='black',
        s=65,
        zorder=8,
        label='Старт $X^0$'
    )

    # Последняя найденная точка.
    # При остановке в 0 итераций её нет.

    if sol is not None:
        ax.scatter(
            [sol[0]],
            [sol[1]],
            color='red',
            marker='*',
            s=180,
            zorder=9,
            label=f'Последняя точка: ({sol[0]:.3f}, {sol[1]:.3f})'
        )

    # Безусловный минимум
    ax.scatter(
        [x_exact[0]],
        [x_exact[1]],
        color='gold',
        edgecolor='black',
        marker='X',
        s=90,
        zorder=8,
        label='Безусловный минимум'
    )

    # Заголовок графика
    if sol is None:
        result_text = "остановка: 0 итераций"
    else:
        result_text = (
            f"итераций: {len(hist) - 1}, "
            f"X = ({sol[0]:.4f}, {sol[1]:.4f})"
        )

    ax.set_title(
        f"{name}, $X^0$ = {x0}\n{result_text}",
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
        facecolor='#bbf7d0',
        edgecolor='darkgreen',
        alpha=0.5,
        label='Допустимая область'
    ),

    Line2D(
        [0], [0],
        color='red',
        lw=1.5,
        marker='o',
        markersize=4,
        label='Траектория итераций'
    ),

    Line2D(
        [0], [0],
        marker='*',
        color='w',
        markerfacecolor='red',
        markeredgecolor='black',
        markersize=12,
        label='Последняя найденная точка'
    ),

    Line2D(
        [0], [0],
        marker='X',
        color='w',
        markerfacecolor='gold',
        markeredgecolor='black',
        markersize=9,
        label='Безусловный минимум'
    )

]

fig.legend(
    handles=legend_elements,
    loc='lower center',
    ncol=2,
    fontsize=8
)

fig.suptitle(
    "Метод внутренней барьерной функции штрафа (вариант 9)",
    fontsize=13
)

plt.tight_layout(rect=(0, 0.07, 1, 1))

plt.show()
