if [ -z "$1" ]
then
    echo "No argument for <migration name> supplied"
    echo "Usage: ./addMigration.sh <migration name>"
else
    dotnet ef migrations add --project src/PingMonitor.WebApi/ $1
fi

