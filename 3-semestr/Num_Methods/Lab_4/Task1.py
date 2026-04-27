import math
import matplotlib.pyplot as plt

# --- 1. ФУНКЦИИ ВАРИАНТА ---
def f1(x):
    return (x + 1) * math.sqrt(x**2 + 1) # Вариант 14

def phi(z):
    return math.atan(z) # Вариант 10

def psi(x):
    return (x - 1) / (x**2 + x + 1) # Вариант 3

def f2(x, t, mu=-0.01):
    # f2(x, t) из постановки задачи
    z = t / (1 + x**2) + mu * x
    return phi(z) * psi(x)

# --- 2. МЕТОД 3/8 (НЬЮТОНА) ---
def simpson_3_8(func, a, b, eps, *args):
    n = 3 # Минимальное N, кратное 3
    
    def calculate(n_steps):
        h = (b - a) / n_steps # Шаг h
        # Формула Ньютона (7.18)
        res = func(a, *args) + func(b, *args)
        for i in range(1, n_steps):
            x_i = a + i * h
            # Коэффициенты 2 для стыков, 3 для внутренних точек
            res += (2 if i % 3 == 0 else 3) * func(x_i, *args)
        return (3 * h / 8) * res

    res_old = 0
    res_new = calculate(n)
    
    # Ищем точность, прибавляя по 3 шага
    while abs(res_new - res_old) > eps:
        n += 3 
        res_old = res_new
        res_new = calculate(n)
        
    return res_new, n

# --- 3. РАСЧЕТЫ ---
# Для u ищем точность 10^-5
u_val, n_u = simpson_3_8(f1, 0, 0.75, 1e-5)

# Параметры для F(t)
a2, b2 = math.pi/4, 3*math.pi/4
c, d, m = 1, 2.5, 15
h_t = (d - c) / m

t_list, F_list = [], []

print(f"Результат u = {u_val:.6f}")
print(f"Вычислено за N = {n_u} шагов") # Теперь будет идти по +3
print("\nТаблица значений F(t):")
print(f"{'i':>2} | {'t_i':>7} | {'F(t_i)':>10}")
print("-" * 25)

for i in range(m + 1):
    t_i = c + i * h_t
    # Для F(t) точность 10^-4
    f_t, _ = simpson_3_8(f2, a2, b2, 1e-4, t_i)
    t_list.append(t_i)
    F_list.append(f_t)
    print(f"{i:2d} | {t_i:7.4f} | {f_t:10.6f}")

# --- 4. ЗЕЛЕНЫЙ ГРАФИК ---
plt.figure(figsize=(10, 5))
plt.plot(t_list, F_list, color='green', marker='o', linewidth=2, label='F(t)')
plt.title('График функции F(t)')
plt.xlabel('t')
plt.ylabel('F(t)')
plt.grid(True, alpha=0.3)
plt.legend()
plt.show()