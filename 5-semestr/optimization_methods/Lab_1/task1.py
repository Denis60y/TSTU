import matplotlib.pyplot as plt
import numpy as np

# Исходные данные
a0 = 5.0
b0 = 11.0
e = 0.01

def fx(x):
    return x**3 - 15 * x**2 + 63 * x + 12

left_bound, right_bound = a0, b0

# Сохраняем историю шагов: (a, b, x1, x2)
steps = []

while True:
    x1 = a0 + 0.25 * (b0 - a0)
    x2 = b0 - 0.25 * (b0 - a0)

    steps.append((a0, b0, x1, x2))

    f1 = fx(x1)
    f2 = fx(x2)

    if f1 < f2:
        b0 = x2
    elif f1 > f2:
        a0 = x1
    else:
        a0 = x1

    if (b0 - a0) < e:
        x_min = a0 + 0.5 * (b0 - a0)
        f_min = fx(x_min)
        break

# --- Визуализация ---
fig, (ax1, ax2) = plt.subplots(2, 1, figsize=(9, 8), sharex=True, 
                               gridspec_kw={'height_ratios': [2, 1.3]})

x_curve = np.linspace(left_bound, right_bound, 400)
y_curve = fx(x_curve)

# 1. Верхний график: функция и найденный минимум
ax1.plot(x_curve, y_curve, label=r"$f(x) = x^3 - 15x^2 + 63x + 12$", color="#1f77b4", linewidth=2)
ax1.axvspan(a0, b0, color="green", alpha=0.2, label=f"Финальный отрезок $[a, b]$ ($\Delta < {e}$)")
ax1.scatter([x_min], [f_min], color="red", s=90, zorder=5, label=f"Минимум ({x_min:.2f}, {f_min:.2f})")
ax1.axvline(x=x_min, color="red", linestyle="--", alpha=0.5)

ax1.set_ylabel("$f(x)$", fontsize=11)
ax1.set_title("Поиск минимума: функция и локализация", fontsize=12)
ax1.grid(True, linestyle=":", alpha=0.6)
ax1.legend(loc="upper left")

# 2. Нижний график: каскадное сужение отрезков по итерациям
# Отображаем первые 8 шагов (или все, если их мало), чтобы график не перегружался
max_display_steps = min(len(steps), 10)

for i in range(max_display_steps):
    cur_a, cur_b, cur_x1, cur_x2 = steps[i]
    y_pos = -i  # Шаги идут сверху вниз

    # Отрезок текущей итерации [a, b]
    ax2.plot([cur_a, cur_b], [y_pos, y_pos], color="#2ca02c", linewidth=3, solid_capstyle='round')
    
    # Точки деления x1 и x2 на этом отрезке
    ax2.scatter([cur_x1, cur_x2], [y_pos, y_pos], color="orange", edgecolor="black", s=45, zorder=4)

ax2.set_yticks([-i for i in range(max_display_steps)])
ax2.set_yticklabels([f"Итер. {i}" for i in range(max_display_steps)])
ax2.set_xlabel("$x$", fontsize=11)
ax2.set_title("Процесс сужения отрезка $[a_k, b_k]$ и точки деления $x_1, x_2$", fontsize=11)
ax2.grid(True, axis="x", linestyle=":", alpha=0.6)

# Добавляем кастомные маркеры в легенду для нижнего графика
from matplotlib.lines import Line2D
legend_elements = [
    Line2D([0], [0], color='#2ca02c', lw=3, label='Текущий отрезок $[a_k, b_k]$'),
    Line2D([0], [0], marker='o', color='w', markerfacecolor='orange', markeredgecolor='black', markersize=7, label='Пробные точки $x_1, x_2$')
]
ax2.legend(handles=legend_elements, loc="upper left")

plt.tight_layout()
plt.show()