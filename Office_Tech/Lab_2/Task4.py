import docx
import docx.enum.text
from docx.shared import Cm, Mm, Pt
from docx.enum.text import WD_LINE_SPACING

personal = []
photos = []
text_photo = []

personal.append(input("Полное название организации: "))

personal.append(input("Название кафедры: "))

personal.append(input("№ лабораторной: "))

personal.append(input("Название дисциплины: "))

personal.append(input("Номер группы: "))

personal.append(input("Фамилия И.О. студента: "))

personal.append(input("Фамилия И.О. преподавателя: "))

personal.append(input("Год: "))

personal.append(input("Цель работы: "))

personal.append(input("Вариант лабораторной: "))

personal.append(input("Задание: "))

personal.append(input("Решение: "))

personal.append(input("Код программы: "))

for i in range(int(input("Количество картинок: "))):
    photos.append(input(f"Путь к картинке номмер{i+1}: "))
    text_photo.append(f"Рисунок {i+1}. {input("Подписть к картинке: ")}")

personal.append(input("Выводы: "))


doc = docx.Document()

style = doc.styles['Normal']
style.font.name = 'Times New Roman'
paragraph_format = style.paragraph_format
paragraph_format.space_after = Pt(0)
paragraph_format.line_spacing_rule = WD_LINE_SPACING.SINGLE

section = doc.sections[-1]
section.top_margin = Cm(2) #Верхний отступ
section.bottom_margin = Cm(2)#Нижний отступ
section.left_margin = Cm(3) #Отступ слева
section.right_margin = Cm(1.5) #Отступ справа

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
add = text.add_run(f"{personal[0]}")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
add = text.add_run("\n\n\n\n\n")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.RIGHT
add = text.add_run(f"{personal[1]}")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
add = text.add_run("\n\n\n\n\n\n\n\n")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
add = text.add_run(f"Отчет по лабораторной работе №{personal[2]}")
add.font.size = Pt(24)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
add = text.add_run(f"по дисциплине «{personal[3]}»")
add.font.size = Pt(16)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
add = text.add_run("\n")
add.font.size = Pt(16)
add = text.add_run("\n\n")
add.font.size = Pt(14)
add = text.add_run("\n\n\n\n")
add.font.size = Pt(18)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
add = text.add_run("                                                           ")
add.font.size = Pt(18)
add = text.add_run(f"Выполнил: студент группы {personal[4]}")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
add = text.add_run(f"                                                                                                {personal[5]}")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
add = text.add_run(f"                                                                            Проверил:  {personal[6]}")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.left_indent = Cm(-0.63)
add = text.add_run("\n\n\n\n")
add.font.size = Pt(12)
add = text.add_run("\n\n\n\n\n")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
add = text.add_run(f"Тамбов {personal[7]}")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(1.25)
p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.JUSTIFY
add = text.add_run("Цель работы:")
add.font.size = Pt(14)
add.bold = True

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(1.25)
add = text.add_run(f"{personal[8]}\n")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(1.25)
p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.JUSTIFY
add = text.add_run("Задание:")
add.font.size = Pt(14)
add.bold = True

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(1.25)
add = text.add_run(f"Вариант №{personal[9]}")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(1.25)
add = text.add_run(f"{personal[10]}\n")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
add = text.add_run("")
add.font.size = Pt(16)
add.bold = True

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(0.95)
add = text.add_run("Решение:")
add.font.size = Pt(14)
add.bold = True

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(0.95)
add = text.add_run(f"{personal[11]}\n")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
add = text.add_run("Листинг программы")
add.font.size = Pt(14)
add.bold = True

text = doc.add_paragraph()
p_fmt = text.paragraph_format
add = text.add_run("")
add.font.size = Pt(10)
add.font.name = "Courier New"

text = doc.add_paragraph()
p_fmt = text.paragraph_format
add = text.add_run(f"{personal[12]}")
add.font.size = Pt(12)
add.font.name = "Consolas"

text = doc.add_paragraph()
p_fmt = text.paragraph_format
add = text.add_run("")
add.font.size = Pt(14)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
add = text.add_run("Результаты работы программы")
add.font.size = Pt(14)
add.bold = True

# text = doc.add_paragraph()
# p_fmt = text.paragraph_format
# p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
# add = text.add_run("КАРТИНКА")
# add.font.size = Pt(12)

# text = doc.add_paragraph()
# p_fmt = text.paragraph_format
# p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
# add = text.add_run("Рисунок 1. Подпись к рисунку")
# add.font.size = Pt(12)

# text = doc.add_paragraph()
# p_fmt = text.paragraph_format
# p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
# add = text.add_run("КАРТИНКА")
# add.font.size = Pt(12)

# text = doc.add_paragraph()
# p_fmt = text.paragraph_format
# p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
# add = text.add_run("Рисунок 2. Подпись к рисунку")
# add.font.size = Pt(12)


for i in range(len(photos)):
    text = doc.add_paragraph()
    p_fmt = text.paragraph_format
    p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
    add = text.add_run(f"{photos[i]}")
    add.font.size = Pt(12)

    text = doc.add_paragraph()
    p_fmt = text.paragraph_format
    p_fmt.alignment = docx.enum.text.WD_ALIGN_PARAGRAPH.CENTER
    add = text.add_run(f"{text_photo[i]}")
    add.font.size = Pt(12)

text = doc.add_paragraph()
p_fmt = text.paragraph_format
add = text.add_run("")
add.font.size = Pt(14)
add.bold = True

text = doc.add_paragraph()
p_fmt = text.paragraph_format
add = text.add_run("")
add.font.size = Pt(14)
add.bold = True
add.font.name = "Courier New"

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(0.95)
add = text.add_run("")
add.font.size = Pt(14)
add.bold = True

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(0.95)
add = text.add_run("Выводы:")
add.font.size = Pt(14)
add.bold = True

text = doc.add_paragraph()
p_fmt = text.paragraph_format
p_fmt.first_line_indent = Cm(0.95)
add = text.add_run(f"{personal[13]}")
add.font.size = Pt(14)

doc.save("resources/Структура отчета.docx")