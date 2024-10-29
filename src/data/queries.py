from .db import _get_cursor
from .tables import Website


def select_websites():
	cur = _get_cursor()
	query = f"SELECT * FROM {Website.tablename}"
	result = cur.execute(query)
	websites = result.fetchall()
	cur.close()

	return [Website(*website) for website in websites]


if __name__ == "__main__":
	websites = select_websites()
	for i in websites:
		print(i.website_id)
		print(i.name)
		print(i.domain)
