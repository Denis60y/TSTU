\c human_resources
SET client_encoding = 'UTF8';

SELECT * FROM employees 
WHERE last_name = 'Смирнова';
 
UPDATE employees
SET phone = '+7 920 555-77-88'
WHERE last_name = 'Смирнова' AND first_name = 'Анна';
 
SELECT * FROM employees 
WHERE last_name = 'Смирнова';

--

SELECT e.last_name, ed.name AS education
FROM employees e 
JOIN education ed ON e.education_id = ed.education_id
WHERE e.last_name = 'Попова';
 
UPDATE employees
SET education_id = (SELECT education_id FROM education WHERE name = 'Высшее: бакалавриат')
WHERE last_name = 'Попова' AND first_name = 'Виктория';
 
SELECT e.last_name, ed.name AS education
FROM employees e 
JOIN education ed ON e.education_id = ed.education_id
WHERE e.last_name = 'Попова';

--

UPDATE employee_positions
SET job_share = 1.00
WHERE employee_id = (SELECT employee_id FROM employees
                     WHERE last_name = 'Петров' AND first_name = 'Никита');
 
SELECT * FROM employee_positions WHERE employee_id = 6;

--

UPDATE employees
SET education_id = (SELECT education_id FROM education WHERE name = 'Среднее профессиональное')
WHERE last_name = 'Волков' 