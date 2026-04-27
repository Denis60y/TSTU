import statistics
import math
import matplotlib.pyplot as plt

t = [1,8,1,1,24,1,18,1,1,1,14,10,1,1,3,19,14,9,1,22,6,8,7,21,1,31,29,1,21,20]

Mx = max(t)
mx = min(t)

n = len(t)
t1 = statistics.mean(t)
D = statistics.variance(t)
sigma = D ** 0.5
V = sigma / t1

print(f"Длинна: {n}")
print(f"Математическое ожидание: {t1}")
print(f"Дисперсия: {D}")
print(f"Среднекадратическое отклонение: {sigma}")
print(f"Коэффициент вариации (V): {V}")

s = sorted(t)
R_s = [math.exp(-val / t1) for val in s]

plt.figure(figsize=(8, 5))
plt.plot(s, R_s, "r", markersize=4)
plt.grid(True, linestyle=':')
plt.legend()
plt.show()
