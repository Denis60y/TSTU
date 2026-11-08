-- Задание 1. Напишите функцию get_employee_count_by_department(department_name VARCHAR), которая принимает в качестве 
-- 6входного параметра имя отдела и возвращает количество сотрудников, работающих в этом отделе

CREATE OR REPLACE FUNCTION get_employee_count_by_department(department_name VARCHAR)
RETURNS INTEGER AS $$
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM employees
        WHERE department = department_name
    );
END;