CREATE DATABASE human_resources;
\c human_resources

CREATE TABLE departments (
    department_id SERIAL PRIMARY KEY,
    name          VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE education (
    education_id SERIAL PRIMARY KEY,
    name         VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE positions (
    position_id SERIAL PRIMARY KEY,
    name        VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE employees (
    employee_id     SERIAL PRIMARY KEY,
    last_name       VARCHAR(255) NOT NULL,
    first_name      VARCHAR(255) NOT NULL,
    middle_name     VARCHAR(255),
    phone           VARCHAR(20) NOT NULL,
    education_id    INTEGER NOT NULL,
    enrollment_date DATE NOT NULL,
    FOREIGN KEY (education_id) REFERENCES education (education_id)
);

CREATE TABLE employee_positions (
    empl_depart_position_id SERIAL PRIMARY KEY,
    employee_id             INTEGER NOT NULL,
    department_id           INTEGER NOT NULL,
    position_id             INTEGER NOT NULL,
    job_share               NUMERIC(3, 2),
    FOREIGN KEY (employee_id)   REFERENCES employees (employee_id),
    FOREIGN KEY (department_id) REFERENCES departments (department_id),
    FOREIGN KEY (position_id)   REFERENCES positions (position_id),
);

CREATE INDEX idx_employees_full_name       ON employees (last_name, first_name, middle_name);
CREATE INDEX idx_employees_enrollment_date ON employees (enrollment_date);
CREATE INDEX idx_employees_education_id    ON employees (education_id);
CREATE INDEX idx_ep_department_id          ON employee_positions (department_id);
CREATE INDEX idx_ep_position_id            ON employee_positions (position_id);

\dt