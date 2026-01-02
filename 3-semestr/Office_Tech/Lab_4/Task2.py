import pandas as pd
import PyPDF2

# Названия стобцов
title = ['Название', 'Авторы', 'регистрационный номер', 'номер заявки', 'правообладатель', 'дата поступления', 'дата регистрации', 'полный путь до файла']

# Путь к первому файлц(текстовому)
path1 = 'resources/input/Текстовый формат/Виртуальная установка «Поршневой компрессор».PDF'

# Открытие файла
with open(path1, 'rb') as pdf_file_obj1:
    pdf_file_reader = PyPDF2.PdfReader(pdf_file_obj1)
    
    # выкачка текста
    first_page = pdf_file_reader.pages[0]
    first_page_text = first_page.extract_text()
    
    # преобразую в массив
    lines = first_page_text.split('\n')

    # достаю нужные данные и пихаю в переменные
    author1 = []
    for i, line in enumerate(lines):
        if "(RU)" in line:
            author1.append(line)
        if "Название программы дляЭВМ:" in line:
            name = lines[i + 1]
        if "Номеррегистрации" in line:
            number = lines[i + 1]
        if "Номеридатапоступления заявки" in line:
            application_number = lines[i + 1][29:-10]
        if "Правообладатель(и)" in line:
            copyright_holder = lines[i + 1] + lines[i + 2] + lines[i + 3] + lines[i + 4][:-5]
        if "Номеридатапоступления заявки" in line:
            date_of_receipt = lines[i + 1][40:]
        if "Датарегистрации" in line:
            registration_date = lines[i][53:]
    
    # Обрабатываю строчки с фамилиями потому что читает через жопу
    author1.pop()
    author1[0] = author1[0][0: 6] + " " + author1[0][6: 11] + " " + author1[0][11: 21]
    author1[1] = author1[1][:-34]
    author1[2] = author1[2][0:7] + " " + author1[2][7:-35]
    author1[3] = author1[3][:-36] + " " + author1[3][14:-28]
    author1[4] = author1[4][:-47] + " " + author1[4][14:-37]
    author1[5] = author1[5][17:-13] + " " + author1[5][32:-6]
    author1[6] = author1[6][:-15] + " " + author1[6][14:-5]

    authors1 = ""
    for i in range(len(author1)):
        authors1 += author1[i] + ", "

    # массив с данными из первого файла
    data1 = []
    data1.append(name)
    data1.append(authors1)
    data1.append(number)
    data1.append(application_number)
    data1.append(copyright_holder)
    data1.append(date_of_receipt)
    data1.append(registration_date)
    data1.append(path1)

data = {}

for i in range(len(title)):
    data[f"{title[i]}"] = data1[i]

df = pd.DataFrame([data])

# Сохраняем в Excel с помощью ExcelWriter
with pd.ExcelWriter('resources/out/4.2/task4.2.xlsx', engine='openpyxl') as writer:
    df.to_excel(writer, index=False, sheet_name='Sheet1')
    
    # Получаем workbook и worksheet
    workbook = writer.book
    worksheet = writer.sheets['Sheet1']
    
    # Устанавливаем индивидуальную ширину столбцов
    # Для всех столбцов кроме последнего - ширина 30
    # Для последнего столбца - ширина 60
    for i, column in enumerate(worksheet.columns, 1):
        column_letter = column[0].column_letter
        
        if i == len(df.columns):  # Последний столбец
            worksheet.column_dimensions[column_letter].width = 60
        else:  # Все остальные столбцы
            worksheet.column_dimensions[column_letter].width = 24