
-- Users table
CREATE TABLE usersSurvey (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100),
    email NVARCHAR(100) UNIQUE,
    created_at DATETIME DEFAULT GETDATE()
);

-- Surveys table
CREATE TABLE surveys (
    survey_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    title NVARCHAR(255) NOT NULL,
    description NVARCHAR(MAX),
    is_anonymous BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

-- Questions table
CREATE TABLE questions (
    question_id INT IDENTITY(1,1) PRIMARY KEY,
    survey_id INT,
    question_text NVARCHAR(MAX) NOT NULL,
    question_type NVARCHAR(50) NOT NULL, -- 'single_choice', 'multiple_choice', 'text', 'scale'
    is_required BIT DEFAULT 1,
    question_order INT,
    FOREIGN KEY (survey_id) REFERENCES surveys(survey_id)
);

-- Options table
CREATE TABLE optionsSurvey (
    option_id INT IDENTITY(1,1) PRIMARY KEY,
    question_id INT,
    option_text NVARCHAR(255) NOT NULL,
    value INT, -- useful for scale-type questions
    FOREIGN KEY (question_id) REFERENCES questions(question_id)
);

-- Responses table
CREATE TABLE responses (
    response_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    question_id INT,
    option_id INT NULL,       -- NULL for text responses
    response_text NVARCHAR(MAX) NULL, -- NULL for choice responses
    responded_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (question_id) REFERENCES questions(question_id),
    FOREIGN KEY (option_id) REFERENCES options(option_id)
);

-- Multiple responses table
CREATE TABLE multiple_responses (
    multi_response_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    question_id INT,
    option_id INT,
    responded_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (question_id) REFERENCES questions(question_id),
    FOREIGN KEY (option_id) REFERENCES options(option_id)
);
