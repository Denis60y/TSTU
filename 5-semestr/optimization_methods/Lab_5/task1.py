
import math
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.lines import Line2D
from matplotlib.patches import Patch
from scipy.optimize import minimize

# ============================================================
# Лабораторная работа 2.5, вариант 9
# Решение общей задачи математического программирования
# комбинированным методом штрафных функций
#
# Целевые функции:
# 1. Эллиптический параболоид
# 2. Функция Розенброка
# ============================================================


# ============================================================
# 1. ПАРАМЕТРЫ ВАРИАНТА 9 (Таблица 2.4)
# ============================================================

a = -3.0
b = -1.0
c = 2.0
d = 5.0
alpha = math.radians(110.0)

# Коэффициенты штрафа
K1 = 1.0
C = 10.0

# Критерий остановки
eps = 1e-4
max_outer = 25

# Параметры внутренней минимизации
inner_xatol = 1e-9
inner_fatol = 1e-9
inner_maxiter = 10000


# ============================================================
# 2. ЦЕЛЕВЫЕ ФУНКЦИИ
# ============================================================

def f_ellipse(x):
    """Целевая функция — эллиптический параболоид."""

    x1, x2 = x[0], x[1]

    u = (x1 - a) * np.cos(alpha) + (x2 - b) * np.sin(alpha)
    v = (x2 - b) * np.cos(alpha) - (x1 - a) * np.sin(alpha)

    return u**2 / c**2 + v**2 / d**2


def f_rosenbrock(x):
    """Целевая функция Розенброка."""

    x1, x2 = x[0], x[1]

    return 100 * (x2 - x1**2)**2 + (1 - x1)**2


# ============================================================
# 3. ФУНКЦИИ ОГРАНИЧЕНИЙ
# ============================================================

def eval_constraints(x1, x2):
    """Вычисление функций f1(X) и f2(X)."""

    # Исходное неравенство:
    # x2^5 + 3*x1^2 - 2*x1 - 5 <= 0

    # Для логарифмического барьера:
    # f1(X) = 5 + 2*x1 - 3*x1^2 - x2^5 >= 0

    f1 = 5 + 2*x1 - 3*x1**2 - x2**5

    # Исходное равенство:
    # 3*x1 - x2^2 = 0

    f2 = 3*x1 - x2**2

    return f1, f2


# ============================================================
# 4. КОМБИНИРОВАННАЯ ФУНКЦИЯ ШТРАФА (2.15)
# ============================================================

def R_combined(x, K, f):
    """Комбинированная внутренняя-внешняя функция штрафа.

    R(X,K) = f(X) - (1/K)*ln(f1(X)) + K*f2(X)^2
    """

    f1, f2 = eval_constraints(x[0], x[1])

    # Логарифм существует только при f1 > 0
    if not np.isfinite(f1) or f1 <= 0:
        return 1e12

    return f(x) - (1.0 / K) * np.log(f1) + K * f2**2


# ============================================================
# 5. АЛГОРИТМ КОМБИНИРОВАННОГО МЕТОДА
# ============================================================

def solve_combined(x_start, f, function_name, start_name):

    x_curr = np.array(x_start, dtype=float)

    # Проверка области определения логарифма
    f1_start, f2_start = eval_constraints(
        x_curr[0], x_curr[1]
    )

    if f1_start <= 0:
        raise ValueError(
            f"Начальная точка {x_start} не подходит: "
            "необходимо f1(X0) > 0."
        )

    K = K1

    # История внешних итераций
    history = [x_curr.copy()]
    history_K = []
    history_rows = []

    print("\n" + "=" * 112)

    print(f"КОМБИНИРОВАННЫЙ МЕТОД — {function_name}")
    print(f"{start_name}: X0 = ({x_curr[0]}, {x_curr[1]})")

    print(f"f1(X0) = {f1_start:.6f}")
    print(f"f2(X0) = {f2_start:.6f}")

    print("=" * 112)

    print(
        f"{'i':>3} | {'K':>10} | {'x1':>12} | {'x2':>12} | "
        f"{'f(X)':>13} | {'f1(X)':>12} | {'f2(X)':>12} | {'||ΔX||':>12}"
    )

    print("-" * 112)

    for iteration in range(1, max_outer + 1):

        # Минимизация вспомогательной функции
        # методом Нелдера-Мида

        res = minimize(
            lambda x: R_combined(x, K, f),
            x_curr,
            method="Nelder-Mead",
            options={
                "xatol": inner_xatol,
                "fatol": inner_fatol,
                "maxiter": inner_maxiter,
            },
        )

        x_next = np.asarray(res.x, dtype=float)

        f1_next, f2_next = eval_constraints(
            x_next[0], x_next[1]
        )

        # Проверка области определения логарифма
        if not np.isfinite(f1_next) or f1_next <= 0:
            raise RuntimeError(
                "Оптимизатор вышел из области f1(X) > 0."
            )

        # Расстояние между соседними приближениями
        diff = np.linalg.norm(x_next - x_curr)

        # Сохраняем историю
        history.append(x_next.copy())
        history_K.append(K)

        history_rows.append({
            "iteration": iteration,
            "K": K,
            "x": x_next.copy(),
            "f": float(f(x_next)),
            "f1": float(f1_next),
            "f2": float(f2_next),
            "diff": float(diff),
            "success": bool(res.success),
        })

        print(
            f"{iteration:>3} | {K:>10.2e} | "
            f"{x_next[0]:>12.7f} | "
            f"{x_next[1]:>12.7f} | "
            f"{f(x_next):>13.6e} | "
            f"{f1_next:>12.6e} | "
            f"{f2_next:>12.6e} | "
            f"{diff:>12.6e}"
        )

        # Критерий остановки
        if diff <= eps:
            break

        # Переход к следующей внешней итерации
        x_curr = x_next
        K *= C

    else:
        print(
            f"Достигнуто максимальное число итераций: {max_outer}"
        )

    x_solution = history_rows[-1]["x"]

    f1_solution, f2_solution = eval_constraints(
        x_solution[0], x_solution[1]
    )

    print("-" * 112)

    print(
        f"Найденное приближение X = "
        f"({x_solution[0]:.9f}, {x_solution[1]:.9f})"
    )

    print(f"f(X) = {f(x_solution):.10f}")
    print(f"f1(X) = {f1_solution:.10e} (требуется > 0)")
    print(f"f2(X) = {f2_solution:.10e} (требуется = 0)")

    print(f"Количество внешних итераций: {len(history_rows)}")

    return (
        x_solution,
        np.array(history),
        np.array(history_K),
        history_rows
    )


# ============================================================
# 6. ДВЕ НАЧАЛЬНЫЕ ТОЧКИ
# ============================================================

# Первая точка удовлетворяет обоим ограничениям
x0_in = [0.75, -1.5]

# Вторая удовлетворяет неравенству,
# но нарушает равенство
x0_out = [1.0, -1.0]

starts = [
    (x0_in, "Старт с выполнением равенства"),
    (x0_out, "Старт с нарушением равенства")
]


# ============================================================
# 7. РАСЧЕТ ДЛЯ ДВУХ ЦЕЛЕВЫХ ФУНКЦИЙ
# ============================================================

tasks = [

    (
        "Эллиптический параболоид",
        f_ellipse,
        (-3.0, -1.0),
        (-4.5, 2.5, -3.0, 2.5),
        None
    ),

    (
        "Функция Розенброка",
        f_rosenbrock,
        (1.0, 1.0),
        (-2.0, 2.5, -2.5, 2.5),
        np.logspace(-2, 3.5, 20)
    )

]

results = []

for name, f, x_exact, box, levels in tasks:

    for x0, start_name in starts:

        x_min, history, k_history, rows = solve_combined(
            x0,
            f,
            name,
            start_name
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


# ============================================================
# 8. ВИЗУАЛИЗАЦИЯ
# Стиль как в лабораторной работе 2.3
# С добавлением зеленой допустимой области
# ============================================================

fig, axes = plt.subplots(2, 2, figsize=(13, 11))

for ax, (
    name, f, x0, x_min, history,
    x_exact, box, levels, k_history
) in zip(axes.flat, results):

    X1, X2 = np.meshgrid(
        np.linspace(box[0], box[1], 400),
        np.linspace(box[2], box[3], 400)
    )

    # Значения целевой функции
    Z = f((X1, X2))

    # Линии уровня
    cs = ax.contour(
        X1,
        X2,
        Z,
        levels=levels if levels is not None else 15,
        cmap="viridis",
        linewidths=0.8
    )

    ax.clabel(
        cs,
        fontsize=7,
        fmt="%.3g"
    )

    # Вычисление ограничений на сетке
    F1, F2 = eval_constraints(X1, X2)

    # Область выполнения неравенства
    feasible_mask = F1 >= 0

    # Светло-зеленая допустимая область неравенства
    ax.contourf(
        X1,
        X2,
        feasible_mask.astype(float),
        levels=[0.5, 1.5],
        colors=["#bbf7d0"],
        alpha=0.5
    )

    # Граница неравенства
    ax.contour(
        X1,
        X2,
        F1,
        levels=[0],
        colors=["darkgreen"],
        linewidths=1.5
    )

    # Отображение равенства:
    # 3*x1 - x2^2 = 0
    # x1 = x2^2 / 3

    curve_x2 = np.linspace(box[2], box[3], 1000)
    curve_x1 = curve_x2**2 / 3

    curve_f1, _ = eval_constraints(
        curve_x1,
        curve_x2
    )

    # Часть равенства внутри допустимой области
    curve_feasible = curve_f1 >= 0

    ax.plot(
        curve_x1[curve_feasible],
        curve_x2[curve_feasible],
        color="darkgreen",
        linewidth=2.0,
        label="Допустимая часть равенства"
    )

    # Часть равенства вне допустимой области
    ax.plot(
        curve_x1[~curve_feasible],
        curve_x2[~curve_feasible],
        color="gray",
        linestyle="--",
        linewidth=1.2,
        label="Равенство вне допустимой области"
    )

    # Траектория внешних итераций
    ax.plot(
        history[:, 0],
        history[:, 1],
        color="red",
        linewidth=1.2,
        marker="o",
        markersize=2.5,
        alpha=0.8,
        label="Траектория итераций"
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
                fontsize=6.5,
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

    # Найденное решение с ограничениями
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
        f"{name}, $X^0$ = {x0}\n"
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


# ============================================================
# 9. ОБЩАЯ ЛЕГЕНДА
# ============================================================

legend_elements = [

    Patch(
        facecolor="#bbf7d0",
        edgecolor="darkgreen",
        alpha=0.5,
        label="Область выполнения неравенства"
    ),

    Line2D(
        [0], [0],
        color="darkgreen",
        lw=2,
        label="Допустимая часть равенства"
    ),

    Line2D(
        [0], [0],
        color="gray",
        lw=1.2,
        linestyle="--",
        label="Равенство вне допустимой области"
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
        label="Найденное решение"
    ),

    Line2D(
        [0], [0],
        marker="*",
        color="w",
        markerfacecolor="gold",
        markeredgecolor="black",
        markersize=14,
        label="Безусловный минимум функции"
    )

]

fig.legend(
    handles=legend_elements,
    loc="lower center",
    ncol=2,
    fontsize=8
)

fig.suptitle(
    "Комбинированный метод штрафных функций (вариант 9)",
    fontsize=13
)

plt.tight_layout(rect=(0, 0.08, 1, 1))

plt.show()
