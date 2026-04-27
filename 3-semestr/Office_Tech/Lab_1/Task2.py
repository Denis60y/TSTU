import numpy as np
import matplotlib.pyplot as plt

f, ax = plt.subplots(2, 2)
f.set_facecolor('#eee')
f.set_size_inches(7, 4)

sum = np.array([22695, 21575, 31289, 26019, 27795, 36152])
sup = np.array([9201, 8586, 11841, 6708, 4952, 11527])
kafe = np.array([2241, 3777, 4034, 3250, 1749, 4401])
transport = np.array([1455, 1109, 1158, 402, 328, 1269])
months = ["Апр.", "Май", "Июнь", "Июль", "Авг.", "Сент."]
other =  np.sum(sum) - np.sum(sup) - np.sum(transport) - np.sum(kafe)

ax[0, 0].plot(months, sum)
ax[0, 0].grid()
ax[0, 0].set_title("Общие расходы")

ax[0, 1].pie(sum, labels=months)

ax[1, 0].plot(months, sup, months, kafe, months, transport)
ax[1, 0].grid()
ax[1, 0].set_title("Расходы по категориям")

ax[1, 1].pie([np.sum(sup), np.sum(kafe), np.sum(transport), np.sum(other)], labels=["Супермаркеты", "Рестораны", "Транспорт", "Другое"])

f.tight_layout()
plt.show()