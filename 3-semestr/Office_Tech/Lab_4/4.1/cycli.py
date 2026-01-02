from matplotlib import pyplot as plt

class cycli:
    cells = 0
    DV = 0
    CV = 0



    def __init__(self,data:list, prov):

        self.minV = self.DV * self.cells
        self.maxV = self.CV * self.cells

        self.polnota = False
        self.variacia = None
        self.Time_sec = 0

        self.prov = prov

        self.Time = []
        self.Vin, self.Iin = [], []
        self.Power_in = []
        self.Vout = []
        self.Iout = []
        self.Power_ch = []
        self.Capa = []
        self.inTmp = []
        self.exttmp = []
        self.B = []
        self.P_graf =[]
        for i in data:
            self.Time.append(i[0])
            self.Vin.append(i[1])
            self.Iin.append(i[2])
            self.Power_in.append(i[3])
            self.Vout.append(i[4])
            self.Iout.append(i[5])
            self.Power_ch.append(i[6])
            self.Capa.append(i[7])
            self.inTmp.append(i[8])
            self.exttmp.append(i[9])
            self.B.append(i[10:])

        self.getVariacia()
        self.initP()


    def __repr__(self):
        return str(f"Тип:{self.variacia};Полнота:{self.polnota};#{self.prov}")
            
    #Доработка полноты
    def getVariacia(self):
        start_v = int(self.Vout[0])
        end_v = int(self.Vout[-1])
        # Рязрядка
        if self.Vout[-1] < self.Vout[0]:
            self.variacia = "Разрядка"
            start_diff = abs(start_v - self.maxV) / self.maxV * 100
            end_diff = abs(end_v - self.minV) / self.minV * 100
            if start_diff <= 10 and end_diff <= 2:
                self.polnota = True


        # Зарядка
        elif self.Vout[-1] > self.Vout[0]:
            self.variacia = "Зарядка"
            start_diff = abs(start_v - self.minV) / self.minV * 100
            end_diff = abs(end_v - self.maxV) / self.maxV * 100
            if start_diff <= 10 and end_diff <= 2:
                self.polnota = True


    
    def GetTimeTotal(self):
        time_list = self.Time
        time_0 = list(map(int, time_list[0].split(":")))
        time_0_sec = time_0[0] * 3600 + time_0[1] * 60 + time_0[2]

        time_1 = list(map(int, time_list[-1].split(":")))
        time_1_sec = time_1[0] * 3600 + time_1[1] * 60 + time_1[2]

        cur_time = time_1_sec - time_0_sec
        return cur_time
    
    def printData(self):
        print(self.polnota)

    def getCapa(self):
        """Емкость в мАч"""
        capa = list(map(int, self.Capa))
        ver2 = abs(capa[-1] - capa[0])
        return abs(capa[-1])

    def getCapaList(self):
        capa = list(map(int, self.Capa))
        return capa

    def initP(self):
        for i in range(len(self.Vout)):
            p = (int(self.Vout[i]) / 1000) * (abs(int(self.Iout[i])) / 1000)
            self.P_graf.append(p)


    def getEneList(self) -> list:
        """
        Рассчитывает накопленную энергию на каждый момент времени в мWh
        Returns:
            energies_wh - время в секундах, энергия в мили ватт-часах
        """
        if len(self.Time) < 2 or len(self.Vout) < 2 or len(self.Iout) < 2:
            return []

        #Время в секундах
        times_sec = self.getTimeSec()

        powers_w = self.P_graf.copy()

        #Численное интегрирование мощности по времени
        energies_wh = [0]  # начальная энергия = 0

        for i in range(1, len(times_sec)):
            # Временной интервал в часах
            dt_hours = (times_sec[i] - times_sec[i - 1]) / 3600.0

            if dt_hours <= 0:
                energies_wh.append(energies_wh[-1])
                continue

            avg_power = (powers_w[i - 1] + powers_w[i]) / 2.0
            d_energy = avg_power * dt_hours * 1000

            # Накопленная энергия
            energies_wh.append(energies_wh[-1] + d_energy)

        return energies_wh


    def getEne(self):
        return  abs(self.getEneList()[-1] - self.getEneList()[0])


    def getVout(self):
        """Возвращает начальное значение напряжения на батареи и конечное"""
        return int(self.Vout[0] ), int(self.Vout[-1])


    def getTimeSec(self):
        times_sec = []
        for time_str in self.Time:
            try:
                h, m, s = map(int, time_str.split(':'))
                times_sec.append(h * 3600 + m * 60 + s)
            except:
                times_sec.append(0)
        return times_sec


    def Creat_base_data(self, data):
        x = data
        h_t = int(len(x)/100)
        x_list = []
        if h_t < 1:
            h_t = 1
        for i in range(0,len(x), h_t):
            x_list.append(x[i])
        return x_list


    def createGraf(self, save_path='temp_chart.png', show=False):
        """
        Создаёт график зависимости
        """
        x = self.Creat_base_data(self.getTimeSec())

        yVout = self.Creat_base_data(self.Vout)

        yIout = self.Creat_base_data(self.Iout)

        # Ток по модулю
        yIout = [abs(int(i)) for i in yIout]
        yVout = [int(v) for v in yVout]


        fig, ax = plt.subplots(3,1,figsize=(12, 10))
        ax1 = ax[0]


        # График НАПРЯЖЕНИЯ
        line1 = ax1.plot(x, yVout, color="blue", linewidth=2, label="Напряжение (В)")

        # Настройка левой оси Y для напряжения
        ax1.set_xlabel('Время, с', fontsize=11)
        ax1.set_ylabel('Напряжение, В', fontsize=11, color="blue")


        # Создаём правую ось Y для ТОКА
        ax2 = ax1.twinx()

        # График ТОКА (правая ось Y, красный)
        line2 = ax2.plot(x, yIout, color="red", linewidth=2, linestyle='--', label="Ток (А)")

        # Настройка правой оси Y для тока
        ax2.set_ylabel('Ток, А', fontsize=11, color="red")


        ax1.grid(True, alpha=0.3)

        # Объединённая легенда
        all_lines = [line1[0], line2[0]]  # line1 и line2 возвращают списки линий
        labels = [l.get_label() for l in all_lines]
        ax1.legend(all_lines, labels, loc='best', fontsize=10)



        #Грфик Мощности
        ax22 = ax[1]
        y = self.Creat_base_data(self.P_graf)
        ax22.plot(x, y, color="blue", label= "Мощность (Вт)")
        ax22.grid(True, alpha=0.3)
        ax22.set_xlabel("Время, с")
        ax22.set_ylabel("мощности на батарее, Вт")
        ax22.legend()

        # Грфик Емкости и энергии
        ax3 = ax[2]
        y = self.Creat_base_data(self.getCapaList())
        ax3.grid(True, alpha=0.3)

        line1 =ax3.plot(x, y, color="blue", label = "Ёмкость (А*ч)")

        ax3.set_xlabel("Время, с")
        ax3.set_ylabel("Емкость, А*ч", color = "blue")

        y2 = self.Creat_base_data(self.getEneList())
        ax4 = ax3.twinx()
        line2 = ax4.plot(x, y2, color="red", linestyle='--', label = "Энергия (Вт*ч)")
        ax4.set_ylabel("Энергия, Вт*ч",color = "red")
        ax4.grid(True, alpha=0.3)

        all_lines = [line1[0], line2[0]]  # line1 и line2 возвращают списки линий
        labels = [l.get_label() for l in all_lines]
        ax4.legend(all_lines, labels, loc='best', fontsize=10)

        # Автоматическая настройка layout
        plt.tight_layout()

        # Сохранение
        plt.savefig(save_path, dpi=150, bbox_inches='tight')
        plt.close()

        if show:
            plt.show()


    def createGrafTemp(self, save_path='temp_chart.png', ):
        if not all([int(i)>0 for i in self.exttmp]):
            return None

        plt.title("График температуры батареи")
        fig, ax = plt.subplots()
        x = self.Creat_base_data(self.getTimeSec())
        y = self.Creat_base_data(list(map(int,self.exttmp)))
        x = self.getTimeSec()
        y = list(map(int,self.exttmp))

        ax.plot(x, y, color="red", linewidth=2)
        ax.set_xlabel("Время,с")
        ax.set_ylabel("Темппература батареи, 'C")

        plt.tight_layout()
        plt.savefig(save_path)
        plt.close()
        return save_path



    def createGrafB(self, save_path='temp_chart.png'):
        proverka = []
        for i in self.B:
            if any([int(j)>0 for j in i]):
                proverka.append(True)
            else:
                proverka.append(False)
        if not any(proverka):
            return None

        colors = ["red", "green", "blue", "yellow", "magenta", "cyan", "black", "orange"]

        fig, ax = plt.subplots()
        x = self.Creat_base_data(self.getTimeSec())
        plt.title("График Напряжения ячеек")

        for i in range(len(self.B[0])):
            y = []
            for j in self.B:
                y.append(int(j[i]))


            y = self.Creat_base_data(y)
            ax.plot(x, y, color=colors[i], linewidth=2, label= f"B{i+1}")
        ax.set_xlabel("Время,с")
        ax.set_ylabel("Напряжение на ячейках, В")
        ax.legend()

        plt.tight_layout()
        plt.savefig(save_path)
        plt.close()
        return save_path

