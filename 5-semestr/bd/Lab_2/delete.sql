\c human_resources
SET client_encoding = 'UTF8';

SELECT * FROM employee_positions WHERE employee_id = 11;
 
DELETE FROM employee_positions
WHERE employee_id = 11 AND department_id = 1;
 
SELECT * FROM employee_positions WHERE employee_id = 11;

--

SELECT * FROM departments;
 
DELETE FROM departments
WHERE name = 'Административно-хозяйственный отдел';
 
SELECT * FROM departments;

--

DELETE FROM departments
WHERE name = 'IT-отдел';
 
SELECT * FROM departments WHERE name = 'IT-отдел';