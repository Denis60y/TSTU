\c human_resources
SET client_encoding = 'UTF8';


CREATE OR REPLACE VIEW view_employee_positions AS
SELECT e.employee_id,
       e.last_name,
       e.first_name,
       e.middle_name,
       d.name      AS department,
       p.name      AS position,
       ep.job_share
FROM employee_positions ep
JOIN employees   e ON ep.employee_id   = e.employee_id
JOIN departments d ON ep.department_id = d.department_id
JOIN positions   p ON ep.position_id   = p.position_id;
 

SELECT * FROM view_employee_positions ORDER BY department, last_name;
 
 --


CREATE OR REPLACE VIEW view_department_stats AS
SELECT d.department_id,
       d.name                                 AS department,
       COUNT(DISTINCT ep.employee_id)         AS employees_count
FROM departments d
LEFT JOIN employee_positions ep ON d.department_id = ep.department_id
GROUP BY d.department_id, d.name;
 
SELECT * FROM view_department_stats ORDER BY employees_count DESC;
 