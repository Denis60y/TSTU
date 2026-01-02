import csv

from PDFCreate import PDFReport

from cycli import cycli
from manager import manager


def add_space(item: str):
    if not item.isalpha():
        s = ''
        for j in range(len(item)):
            if not item[j].isdigit():
                s += f" {item[j:]}"
                break
            else:
                s += f"{item[j]}"
        return s.strip()
    else:
        return item.strip()

def main(file_patch):
    item = False
    data = False

    # file_path = '1.tsv'
    file_path = file_patch
    dat = {}
    di = {}




    with open(file_path, newline='') as file:
        reader = csv.reader(file, delimiter='\t')
        previous_time = None
        l = list(reader)
        counter_cycle = 0
        for i in range(0, len(l)):
            if l[i][0].strip() == "==Items==":
                item = True
                continue
            if l[i][0].strip() == "==Data==":
                item = False
                data = True
                continue
            if l[i][0].strip() == "==End==":
                break
            if item:
                for j in l[i]:
                    if ":" in j:
                        j = j.split(":")
                        di[j[0]] = add_space(j[1])
                    else:
                        di[j] = "Нет данных"
            if data and l[i][0].strip():  # Проверяем, что строка не пустая
                try:
                    # Разбиваем время
                    time_parts = list(map(int, l[i][0].split(":")))
                    current_time = time_parts[0] * 3600 + time_parts[1] * 60 + time_parts[2]

                    if previous_time is not None:
                        # Если разница во времени больше 2 секунд - начинаем новый цикл
                        if abs(previous_time - current_time) > 10:
                            counter_cycle += 1
                            dat[f"{counter_cycle}"] = [l[i]]
                        else:
                            # Добавляем в существующий цикл
                            if f"{counter_cycle}" not in dat:
                                dat[f"{counter_cycle}"] = [l[i]]
                            else:
                                dat[f"{counter_cycle}"].append(l[i])
                    else:
                        # Первая запись данных
                        dat["0"] = [l[i]]

                    previous_time = current_time

                except (ValueError, IndexError):
                    continue

    spisok = []


    cycli.cells = int(di['Cells'].split()[0])
    cycli.DV = int(di['DV'].split()[0])
    cycli.CV = int(di['CV'].split()[0])

    for i in dat:
        spisok.append(cycli(dat[i], i))

    m = manager(spisok)
    pdf = PDFReport(m ,di)
    pdf.createPDF()


if __name__ == "__main__":
    main("C:/VScodeProjects/3-semestr/Office_Tech/Lab_4/4.1/data/2024-09-16_21-23-32.tsv")
