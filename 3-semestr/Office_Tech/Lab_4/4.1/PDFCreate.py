import os

from fpdf import FPDF


class PDFReport(FPDF):
    def __init__(self, manager, data_item, name_file = "myPDF.pdf"):
        self.name = name_file
        self.mgr = manager
        self.data_item = data_item
        self.cycles = self.mgr.getData()
        super().__init__()
        self.add_font('NS', '', 'C:/VScodeProjects/3-semestr/Office_Tech/Lab_4/4.1/Noto_Sans/NotoSans-VariableFont_wdth,wght.ttf', uni=True)
        self.set_font("NS", size=10)
        self.add_page()

    def add_section_title(self, title):
        self.set_font("NS", size=12)
        self.cell(0, 10, title, ln=True, align='L')
        self.set_font("NS", size=10)
        self.ln(2)

    def add_table(self, data, col_widths, align='L'):
        for row in data:
            for i, cell in enumerate(row):
                self.cell(col_widths[i], 8, str(cell), border=1, align=align)
            self.ln()

    def add_image(self, image_path, width=180, x=10):
        if os.path.exists(image_path):
            self.image(image_path, x=x, w=width)
            self.ln(5)

    def create_item_table(self):
        self.add_section_title("Параметры тестирования")
        table_data = [["Ключ", "Значение", "Ключ", "Значение"]]
        di_item = list(self.data_item.items())
        for i in range(0, len(di_item), 2):
            row_data = []
            if i < len(di_item):
                row_data.extend(di_item[i])
            else:
                row_data.extend(["", ""])
            if i + 1 < len(di_item):
                row_data.extend(di_item[i + 1])
            else:
                row_data.extend(["", ""])
            table_data.append(row_data)

        self.add_table(table_data, [45, 45, 45, 45])
        self.ln(10)


    def create_data_table(self):
        self.add_section_title("Результаты тестирования")

        # Получаем данные
        time_chg = self.mgr.getTimeChg()
        time_dsc = self.mgr.getTimeDsc()
        cyc_chg = self.mgr.getCycChg()
        cyc_dsc = self.mgr.getCycDsc()
        cap_dsc = self.mgr.getCapDsc()
        cap_chg = self.mgr.getCapChg()
        ene_dsc = self.mgr.getEneDsc()
        ene_chg = self.mgr.getEneChg()

        data = [
            ["Параметр", "Значение", "Параметр", "Значение"],
            ["Общее время", f"{self.mgr.getTotalTime() / 3600:.2f} ч", "Циклов заряда",
             f"{cyc_chg[0]} ({cyc_chg[1]} полных)"],
            ["Среднее время заряда", f"{time_chg[0]:.0f} с ±{time_chg[1]:.1f}%", "Циклов разряда",
             f"{cyc_dsc[0]} ({cyc_dsc[1]} полных)"],
            ["Среднее время разряда", f"{time_dsc[0]:.0f} с ±{time_dsc[1]:.1f}%", "Ёмкость заряда",
             f"{cap_chg[0]:.1f} мАч ±{cap_chg[1]:.1f}%"],
            ["Ёмкость разряда", f"{cap_dsc[0]:.1f} мА*ч ±{cap_dsc[1]:.1f}%", "Энергия заряда",
             f"{ene_chg[0]:.1f} мВтч ±{ene_chg[1]:.1f}%"],
            ["Энергия разряда", f"{ene_dsc[0]:.1f} мВт*ч ±{ene_dsc[1]:.1f}%", "", ""]
        ]

        self.add_table(data, [45, 45, 45, 45])

    def create_cycle_details(self):
        self.add_section_title("Детали по циклам")

        for i, cycle in enumerate(self.cycles, 1):
            self.set_font("NS", size=11)
            self.cell(0, 10, f"Цикл #{i}: {cycle.variacia}", ln=True)
            self.set_font("NS", size=10)

            # Сводная таблица цикла
            v_start, v_end = cycle.getVout()
            cycle_data = [
                ["Параметр", "Значение"],
                ["Продолжительность", f"{cycle.GetTimeTotal()} с"],
                ["Начальное напряжение", f"{v_start / 1000:.2f} В"],
                ["Конечное напряжение", f"{v_end / 1000:.2f} В"],
                ["Ёмкость", f"{cycle.getCapa() / 1000:.2f} А*ч"],
                ["Энергия", f"{cycle.getEne() / 1000:.3f} Вт*ч"],
                ["Полнота цикла", "Да" if cycle.polnota else "Нет"]
            ]

            col_width = 50
            for row in cycle_data:
                self.cell(col_width, 8, row[0], border=1)
                self.cell(col_width, 8, row[1], border=1, ln=True)

            self.ln(5)

            # Создаем графики для каждого цикла
            temp_path = f"temp_cycle_{i}_voltage.png"
            cycle.createGraf(save_path=temp_path, show=False)
            self.add_image(temp_path)


            temp_path = f"temp_cycle_{i}_temperature.png"
            if cycle.createGrafTemp(temp_path) is not None:
                self.add_image(temp_path)

            temp_path = f"temp_cycle_{i}_B.png"
            if cycle.createGrafB(temp_path) is not None:
                self.add_image(temp_path)

            self.ln(5)

    def create_all_graf(self):
        """Создает общие графики за все время тестирования"""
        self.add_section_title("Общие графики тестирования")
        temp = self.mgr.CreateGraf()
        for i in temp:
            self.add_image(i)


    def createPDF(self):
        self.create_item_table()
        self.create_data_table()
        self.create_cycle_details()
        self.create_all_graf()
        #Удаляем временные файлы
        temp_files = [f for f in os.listdir() if f.startswith("temp")]
        for f in temp_files:
            try:
                os.remove(f)
            except:
                pass
        self.output(self.name)

