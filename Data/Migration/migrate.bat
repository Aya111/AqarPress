@echo off
if "%1" == "rollback" goto rollback
if "%1" == "" goto migrate

goto error

:migrate
migrate -db SqlServer2014 -connection "Server=DESKTOP-1RNONJG\AYAMSSQLSERVER;Database=AqarPress;Integrated Security=True;" -assembly "AqarPress.Migration.dll"
goto done

:rollback
migrate -db SqlServer2014 -connection "Server=DESKTOP-1RNONJG\AYAMSSQLSERVER;Database=AqarPress;Integrated Security=True;" -assembly "AqarPress.Migration.dll" -task rollback:all
goto done

:error
echo "No valid command"

:done
echo "Completed"
