import numpy as np
import matplotlib.pyplot as plt

# Заданная функция f(x)
def f(x):
    return np.exp(-x) - x

# Первая производная функции
def f_prime(x):
    return -np.exp(-x) - 1

# --- Параметры расчета ---
a_val = 0.5 
b_val = 0.6 # Начальное приближение (корень f(x)=0 находится около 0.5-0.6)
epsilon = 0.001    # Требуемая точность
max_iterations = 50  # Максимальное количество итераций

print(f"f(a) = {f(a_val)}")
print(f"f(b) = {f(b_val)}\n")

if(f(a_val)*f(b_val<0)):
    print("Условие f(a)f(b)<0 выполняется\n")
else:
    print("Условие f(a)f(b)<0 не выполняется\n")

def modified_newton_method(x0, eps, max_iter):
    
    # Вычисление производной один раз в начальной точке
    f_prime_x0 = f_prime(x0)

    x_current = x0
    
    print("------------------------------------------")
    print("| Итерация | x_k         | f(x_k)      |")
    print("------------------------------------------")


    for k in range(max_iter):
        
        # Модифицированная итерационная формула
        x_next = x_current - f(x_current) / f_prime_x0
        
        abs_error = abs(x_next - x_current)
        
        # Вывод результатов итерации
        print(f"| {k+1:8} | {x_next:.9f} | {f(x_next):.6e}|")
        
        
        if abs_error < eps:
            print("------------------------------------------")
            print(f"\nПроцесс сошелся за {k + 1} итераций.")
            return x_next

        x_current = x_next

    print("------------------------------------------")
    print(f"\n❌ Не удалось сойтись за {max_iter} итераций.")
    return x_current

# --- Запуск расчета ---
root = modified_newton_method(a_val, epsilon, max_iterations)

print(f"\nПриближенное значение корня: x* ≈ {root:.9f}")
print(f"Проверка: f(x*) = {f(root):.2e}")


# --- Построение графика ---

# Диапазон значений x для графика
x_vals = np.linspace(0, 1.0, 400)
plt.plot(x_vals, f(x_vals), label='f(x) = e^(-x) - x', color='blue')

# Точка начала a_val
plt.plot(a_val, f(a_val), 'go', markersize=8, label=f'Начальная точка $x_0 = {a_val}$')

# Касательная в точке a_val
f_prime_a_val = f_prime(a_val)
tangent_y = f_prime_a_val * (x_vals - a_val) + f(a_val)
plt.plot(x_vals, tangent_y, 'r--', label=f'Касательная в $x_0 = {a_val}$')

# Точка найденного корня
plt.plot(root, f(root), 'rx', markersize=10, mew=2, label=f'Найденный корень x* = {root:.4f}')

#Ось Х
plt.plot([-10, 10], [0, 0], "black")

plt.title('График функции и ее касательная (Модифицированный метод Ньютона)')
plt.legend()
plt.grid(True)
plt.ylim(-0.5, 1.5) # Немного настроим границы по Y для лучшей видимости
plt.xlim(0, 1.0) # Немного настроим границы по X для лучшей видимости
plt.show()