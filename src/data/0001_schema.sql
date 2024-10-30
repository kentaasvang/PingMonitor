
CREATE TABLE website (
	website_id TEXT PRIMARY KEY NOT NULL,
	name TEXT NOT NULL,
    description TEXT,
    domain TEXT NOT NULL
);

	
CREATE TABLE uptime_log_result (
    uptime_log_result_id TEXT PRIMARY KEY NOT NULL,
    website_id TEXT NOT NULL,
	date TEXT NOT NULL,
    status_code INTEGER NOT NULL,
    response_time REAL NOT NULL,

    FOREIGN KEY (website_id) REFERENCES website(website_id)
);


INSERT INTO website (website_id, name, description, domain)
VALUES ("256a4a81-6cb7-4f87-9cf4-e9c1b12eafb7", "HSOmsorg", "", "https://www.hsomsorg.no");
