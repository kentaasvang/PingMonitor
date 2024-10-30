from uuid import uuid4
from .db import _get_cursor
from .tables import Website, UptimeLogResult


def select_websites():
	cur = _get_cursor()
	query = f"SELECT * FROM {Website.tablename}"
	result = cur.execute(query)
	websites = result.fetchall()
	cur.close()

	return [Website(*website) for website in websites]


def insert_uptime_log_result(uptime_log_result: UptimeLogResult):
    cur = _get_cursor()

    query = f"""
    INSERT INTO {UptimeLogResult.tablename} (uptime_log_result_id, website_id, date, status_code, response_time)
    VALUES (?, ?, ?, ?, ?);

    """

    values = (
            str(uuid4()), 
            uptime_log_result.website_id, 
            uptime_log_result.date, 
            uptime_log_result.status_code,
            uptime_log_result.response_time
    )

    cur.execute(query, values)
    cur.commit()
    cur.close()


if __name__ == "__main__":
	websites = select_websites()
	for i in websites:
		print(i.website_id)
		print(i.name)
		print(i.domain)
