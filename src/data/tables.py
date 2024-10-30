# TODO: should I split tables in read and write-tables ?

class Website:

    tablename = "website"

    def __init__(self, website_id, name, description, domain):
        self.website_id = website_id
        self.name = name
        self.description = description
        self.domain = domain


class UptimeLogResult:

    tablename = "uptime_log_result"

    def __init__(self, uptime_log_result_id, website_id, date, status_code, response_time):
        self.uptime_log_result_id = uptime_log_result_id
        self.website_id = website_id
        self.date = date
        self.status_code = status_code
        self.response_time = response_time
