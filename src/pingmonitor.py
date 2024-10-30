#!./venv/bin/python
# TODO: add logging
import time
import datetime
import requests
from uuid import uuid4
from data.queries import select_websites, insert_uptime_log_result
from data.tables import UptimeLogResult

def main():
    # get all websites
    websites = select_websites()

    # request all websites
    for website in websites:
        uptime_log_result = get_uptime_log_result(website)
        insert_uptime_log_result(uptime_log_result)

    print("Finished.")


def get_uptime_log_result(website):

    start_time = time.time()
    result = requests.get(website.domain, allow_redirects=True)
    response_time = time.time() - start_time
    uptime_vals = (
            str(uuid4()), 
            website.website_id, 
            datetime.datetime.now().isoformat(),
            result.status_code,
            response_time
            )

    uptime_log_result = UptimeLogResult(*uptime_vals)
    return uptime_log_result



if __name__ == "__main__": 
    main()
