
CREATE TABLE website (
	website_id TEXT PRIMARY KEY NOT NULL,
	name TEXT NOT NULL,
	domain TEXT NOT NULL
);


CREATE TABLE ping_result (
	ping_result_id TEXT PRIMARY KEY NOT NULL,
	website_id TEXT NOT NULL,
	date TEXT CURRENT_TIMESTAMP NOT NULL,
	bytes INTEGER,
	[from] TEXT,
	ip TEXT,
	icmp_seq INTEGER,
	ttl INTEGER,
	time REAL,

	FOREIGN KEY (website_id) REFERENCES website(website_id)
);
	

