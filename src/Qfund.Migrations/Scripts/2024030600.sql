create table qf.transactions
(
    "Id"              uuid      default gen_random_uuid()                not null
        primary key,
    "AccountId"       uuid                                               not null,
    "Commission"      numeric   default 0,
    "Date"            timestamp default (now() AT TIME ZONE 'utc'::text) not null,
    "Quantity"        numeric   default 0                                not null,
    "Kind"            smallint  default 0                                not null,
    "Price"           numeric   default 0                                not null,
    "TransactionType" smallint  default 0                                not null,
    "Value"           numeric   default 0                                not null
);
