CREATE TABLE IF NOT EXISTS qf."transactions" (
    "id" uuid primary key default gen_random_uuid(),
    "date" timestamp not null default(now() at time zone 'utc'),
    "quantity" decimal not null default 0

);