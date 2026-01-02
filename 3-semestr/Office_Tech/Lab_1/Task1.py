import numpy as np
import matplotlib.pyplot as plt

f, ax = plt.subplots(2, 2)
f.set_facecolor('#eee')

ax[0, 0].plot(np.arange(0, 5, 1), np.random.random(5), color="#228B22")
ax[0, 0].grid()

ax[0, 1].scatter(np.random.normal(0, 2, 100), np.random.normal(0, 2, 100), color="#2E8B57")
ax[0, 1].grid()

ax[1, 0].bar(np.arange(0, 5, 1), np.random.random(5), color="#228B22")
ax[1, 0].grid()

ax[1, 1].pie(np.random.random(5), frame=True, colors=["#ADFF2F", "#6B8E23", "#98FB98", "#9ACD32", "#2E8B57"])

plt.show()