import math
import matplotlib.pyplot as plt

def f(x):
    return (math.e **(-x)) - x

def g(x):
    return (math.e ** (-x)) 

epsilon = 0.001

x_prev = -1.5      # Произвольная точка
x_curr = g(x_prev) 

X = [x_curr]

# Координаты для построения ломаной
plot_X = [x_prev] 
plot_Y = [x_prev] 

# Условие остановки
while abs(x_curr - x_prev) > epsilon:
    
    plot_X.append(x_prev)  
    plot_Y.append(x_curr)  

    plot_X.append(x_curr)  
    plot_Y.append(x_curr)  
    
    x_prev = x_curr
    x_curr = g(x_prev)
    X.append(x_curr)

plot_X.append(x_prev)
plot_Y.append(g(x_prev))

for i in range(len(X)):
    print(f"{i+1} итерация: ", X[i])

print(f"Приближенный корень: {x_prev}")

# --- Построение графика ---

plt.plot(plot_X, plot_Y, '-', label='Итерации')

plt.plot([x_prev, x_prev], [0, x_prev], "--g")
plt.plot(x_prev, 0, "og")

plt.plot([0, 0], [-10, 10], "black")
plt.plot([-10, 10], [0, 0], "black")

plt.axvspan(0.5, 0.6, facecolor='lightgreen', alpha=0.3)

x_vals = [i/100 for i in range(-200, 250)]
plt.plot(x_vals, [g(x) for x in x_vals], 'r-', label='$y=e^{-x}$')
plt.plot(x_vals, x_vals, 'y-', label='$y=x$') 

# Настройки графика
plt.title('Метод простой итерации')
plt.grid(True)
plt.legend()
plt.axis('equal') 
plt.xlim(-0.2, 1.25)
plt.ylim(-0.2, 1.2)
plt.show()