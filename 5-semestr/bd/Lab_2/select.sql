\c human_resources
SET client_encoding = 'UTF8';

-- SELECT   столбцы
-- FROM     таблица
-- JOIN     другая_таблица ON условие_связи
-- WHERE    условие_для_строк
-- GROUP BY столбцы_группировки
-- HAVING   условие_для_групп
-- ORDER BY сортировка;


SELECT * FROM employees
ORDER BY last_name;


SELECT e.last_name, e.first_name, d.name, p.name
FROM employee_positions ep
JOIN employees e   ON ep.employee_id   = e.employee_id
JOIN departments d ON ep.department_id = d.department_id
JOIN positions p   ON ep.position_id   = p.position_id;


SELECT e.last_name, e.first_name, ed.name, e.enrollment_date
FROM employees e
JOIN education ed ON e.education_id = ed.education_id
WHERE ed.name LIKE 'Высшее%'
  AND e.enrollment_date > '2020-01-01';


SELECT d.name, COUNT(*)
FROM employee_positions ep
JOIN departments d ON ep.department_id = d.department_id
GROUP BY d.name;


SELECT d.name, COUNT(*)
FROM employee_positions ep
JOIN departments d ON ep.department_id = d.department_id
GROUP BY d.name
HAVING COUNT(*) > 5;
 