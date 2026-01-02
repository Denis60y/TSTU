from matplotlib import pyplot as plt


class manager:

    def __init__(self, data:list):
        self.data = data

    def getData(self):
        return self.data

    def getTotalTime(self):
        totalTime = 0
        for i in self.data:
            totalTime += i.GetTimeTotal()
        return totalTime

    def getTimeChg(self):
        """Возврщает среднее значение result и Отклонение deviation в процентах"""
        list_time = []
        for i in self.data:
            if i.variacia == "Зарядка" and i.polnota == True:
                list_time.append(i.GetTimeTotal())
        if len(list_time) == 0:
            return (0,0)
        result = sum(list_time) / len(list_time)
        deviation =(( max(list_time) - min(list_time) ) / result) *100
        return (result, deviation)

    def getTimeDsc(self):
        """Возврщает среднее значение result и Отклонение deviation в процентах"""
        list_time = []
        for i in self.data:
            if i.variacia == "Разрядка" and i.polnota == True:
                list_time.append(i.GetTimeTotal())
        if len(list_time) == 0:
            return (0,0)
        result = sum(list_time) / len(list_time)
        deviation =(( max(list_time) - min(list_time) ) / result) *100
        return (result, deviation)

    def getCycChg(self):
        """Возвращает количество всех циклов зарядки и количество полных"""
        counter = 0
        counter_p = 0
        for i in self.data:
            if i.variacia == "Зарядка":
                counter += 1
                if i.polnota == True:
                    counter_p += 1
        return (counter, counter_p)

    def getCycDsc(self):
        """Возвращает количество всех циклов разрядки и количество полных"""
        counter = 0
        counter_p = 0
        for i in self.data:
            if i.variacia == "Разрядка":
                counter += 1
                if i.polnota == True:
                    counter_p += 1
        return (counter, counter_p)

    def getCapDsc(self):
        """Возвращает Среднее значение ёмкости разрядки и отклонение в %"""
        list_cap =[]
        for i in self.data:
            if i.variacia == "Разрядка":
                list_cap.append(i.getCapa())
        if len(list_cap) == 0:
            return (0,0)
        result = sum(list_cap) / len(list_cap)
        deviation =(( max(list_cap) - min(list_cap) ) / result) *100
        return (result, deviation)

    def getCapChg(self):
        """Возвращает Среднее значение ёмкости зарядки и отклонение в %"""
        list_cap =[]
        for i in self.data:
            if i.variacia == "Зарядка":
                list_cap.append(i.getCapa())
        if len(list_cap) == 0:
            return (0,0)
        result = sum(list_cap) / len(list_cap)
        deviation =(( max(list_cap) - min(list_cap) ) / result) *100
        return (result, deviation)


    def getEneDsc(self):
        """Возвращает Среднее значение энергии разрядки и отклонение в %"""
        list_ene =[]
        for i in self.data:
            if i.variacia == "Разрядка":
                list_ene.append(i.getEne())
        if len(list_ene) == 0:
            return (0,0)
        result = sum(list_ene) / len(list_ene)
        deviation =(( max(list_ene) - min(list_ene) ) / result) *100
        return (result, deviation)

    def getEneChg(self):
        """Возвращает Среднее значение энергии зарядки и отклонение в %"""
        list_ene =[]
        for i in self.data:
            if i.variacia == "Зарядка":
                list_ene.append(i.getEne())
        if len(list_ene) == 0:
            return (0,0)
        result = sum(list_ene) / len(list_ene)
        deviation =(( max(list_ene) - min(list_ene) ) / result) *100
        return (result, deviation)

    def CreateGraf(self):
        """Создает Общие графики и возвращает список"""
        all_time = []
        all_vout = []
        all_iout = []
        all_P = []

        all_cap = []
        all_ene = []


        all_vin = []
        all_iin = []

        all_exttmp = []
        all_intmp = []
        all_cells = [[] for _ in range(8)]

        time_offset = 0
        for cycle in self.data:
            try:
                times = cycle.getTimeSec()
                # Нормализуем время
                norm_times = [t + time_offset for t in times]
                all_time.extend(norm_times)

                # Преобразуем данные

                all_vout.extend([float(v) / 1000 for v in cycle.Vout])  # в В

                all_P.extend(cycle.P_graf)  # в В

                all_iout.extend([abs(float(i)) / 1000 for i in cycle.Iout])  # в А


                all_cap.extend(cycle.getCapaList())
                all_ene.extend(cycle.getEneList())

                all_vin.extend([float(v) / 1000 for v in cycle.Vin])  # в В

                all_iin.extend([abs(float(i)) / 1000 for i in cycle.Iin])  # в А

                all_exttmp.extend([float(t) for t in cycle.exttmp])

                all_intmp.extend([float(t) for t in cycle.inTmp])


                # Данные по ячейкам
                for i in range(len(cycle.B[0])):
                    cell_data = [float(row[i]) / 1000 for row in cycle.B]  # в В
                    all_cells[i].extend(cell_data)


                time_offset += times[-1] + 1  # +1 секунда между циклами
            except:
                continue

        temp_list = ["temp_overall1.png","temp_overall2.png","temp_overall3.png","temp_overall4.png","temp_overall5.png","temp_overall6.png","temp_overall7.png"]
        # try:
        fig, ax1= plt.subplots(1, 1, figsize=(12, 10))

        # График напряжения и тока
        ax1.plot(all_time, all_vout, 'b-', label='Напряжение (В)')
        ax1.set_xlabel('Время, с')
        ax1.set_ylabel('Напряжение, В', color='b')
        ax1.tick_params(axis='y', labelcolor='b')
        ax1.grid(True, alpha=0.3)

        ax1_twin = ax1.twinx()
        ax1_twin.plot(all_time, all_iout, 'r--', label='Ток (А)')
        ax1_twin.set_ylabel('Ток, А', color='r')
        ax1_twin.tick_params(axis='y', labelcolor='r')

        lines1, labels1 = ax1.get_legend_handles_labels()
        lines2, labels2 = ax1_twin.get_legend_handles_labels()
        ax1.legend(lines1 + lines2, labels1 + labels2, loc='upper right')

        plt.tight_layout()


        plt.savefig(temp_list[0], dpi=150)
        plt.close()

        fig, ax2 = plt.subplots(1, 1, figsize=(12, 10))
        #График мощности
        ax2.plot(all_time, all_P, 'g-', label='Мощность (Вт)')
        ax2.set_xlabel('Время, с')
        ax2.set_ylabel('Мощность, Вт')
        ax2.grid(True, alpha=0.3)
        ax2.legend()

        plt.tight_layout()


        plt.savefig(temp_list[1], dpi=150)
        plt.close()

        fig,  ax3 = plt.subplots(1, 1, figsize=(12, 10))
        # График Емкости и Энергии
        ax3.plot(all_time, all_cap, 'b-', label='Емкость (А*ч)')
        ax3.set_xlabel('Время, с')
        ax3.set_ylabel('Емкость, А*ч', color='b')
        ax3.tick_params(axis='y', labelcolor='b')
        ax3.grid(True, alpha=0.3)

        ax3_twin = ax3.twinx()
        ax3_twin.plot(all_time, all_ene, 'r--', label='Энергия (Вт*ч)')
        ax3_twin.set_ylabel('Энергия, Вт*ч', color='r')
        ax3_twin.tick_params(axis='y', labelcolor='r')

        lines1, labels1 = ax3.get_legend_handles_labels()
        lines2, labels2 = ax3_twin.get_legend_handles_labels()
        ax3.legend(lines1 + lines2, labels1 + labels2, loc='upper right')

        plt.tight_layout()


        plt.savefig(temp_list[2], dpi=150)
        plt.close()

        fig, ax4 = plt.subplots(1, 1, figsize=(12, 10))
        # График напряжения и тока на входе
        ax4.plot(all_time, all_vin, 'b-', label='Напряжение (В)')
        ax4.set_xlabel('Время, с')
        ax4.set_ylabel('Напряжение, В', color='b')
        ax4.tick_params(axis='y', labelcolor='b')
        ax4.grid(True, alpha=0.3)

        ax4_twin = ax4.twinx()
        ax4_twin.plot(all_time, all_iin, 'r--', label='Ток (А)')
        ax4_twin.set_ylabel('Ток, А', color='r')
        ax4_twin.tick_params(axis='y', labelcolor='r')

        lines1, labels1 = ax4.get_legend_handles_labels()
        lines2, labels2 = ax4_twin.get_legend_handles_labels()
        ax4.legend(lines1 + lines2, labels1 + labels2, loc='upper right')

        plt.tight_layout()


        plt.savefig(temp_list[3], dpi=150)
        plt.close()


        # График мощности
        fig, ax5 = plt.subplots(1, 1, figsize=(12, 10))
        power_in = [v * i for v, i in zip(all_vin, all_iin)]
        ax5.plot(all_time, power_in, 'g-', label='Входная мощность (Вт)')
        ax5.set_xlabel('Время, с')
        ax5.set_ylabel('Мощность, Вт')
        ax5.grid(True, alpha=0.3)
        ax5.legend()


        plt.tight_layout()


        plt.savefig(temp_list[4], dpi=150)
        plt.close()

        # 3. График ячеек
        proverka = []
        for i in all_cells:
            if any([float(j)>0 for j in i]):
                proverka.append(True)
            else:
                proverka.append(False)
        if not any(proverka):
            del temp_list[5]
        else:
            fig, ax = plt.subplots(figsize=(12, 6))
            colors = ['r', 'g', 'b', 'y', 'm', 'c', 'k', 'orange']
            for i in range(len(all_cells)):

                ax.plot(all_time, all_cells[i], color=colors[i], label=f'B{i + 1}')

            ax.set_xlabel('Время, с')
            ax.set_ylabel('Напряжение, В')
            ax.grid(True, alpha=0.3)
            ax.legend()
            plt.tight_layout()

            plt.savefig(temp_list[5], dpi=150)
            plt.close()


        # 4. График температур
        fig, ax = plt.subplots(figsize=(12, 6))
        if any(temp > 0 for temp in all_exttmp):
            ax.plot(all_time, all_exttmp, 'r-', label='Температура батареи')
        ax.plot(all_time, all_intmp, 'b--', label='Температура устройства')
        ax.set_xlabel('Время, с')
        ax.set_ylabel('Температура, °C')
        ax.grid(True, alpha=0.3)
        ax.legend()
        plt.tight_layout()


        plt.savefig(temp_list[-1], dpi=150)
        plt.close()

        return temp_list

    def __repr__(self):
        total_time = self.getTotalTime()
        time_chg = self.getTimeChg()
        time_dsc = self.getTimeDsc()
        cyc_chg = self.getCycChg()
        cyc_dsc = self.getCycDsc()
        cap_dsc = self.getCapDsc()
        cap_chg = self.getCapChg()

        # Форматируем строку с переносами для удобства чтения
        return (f"TotalTime: {total_time:.1f}\n"
                f"Зарядка - Время: {time_chg[0]:.1f}сек ±{time_chg[1]:.1f}%, "
                f"Циклы: {cyc_chg[0]}({cyc_chg[1]} полных), "
                f"Ёмкость: {cap_chg[0]:.1f}  ±{cap_chg[1]:.1f}%\n"
                f"Разрядка - Время: {time_dsc[0]:.1f}сек ±{time_dsc[1]:.1f}%, "
                f"Циклы: {cyc_dsc[0]}({cyc_dsc[1]} полных), "
                f"Ёмкость: {cap_dsc[0]:.1f}  ±{cap_dsc[1]:.1f}%")
