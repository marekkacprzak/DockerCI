FROM mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

COPY ./wait-and-run.sh .
COPY ./CreateDatabaseAndSeed.sql .

CMD /wait-and-run.sh
