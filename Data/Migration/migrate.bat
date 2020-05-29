@echo off
if "%1" == "rollback" goto rollback
if "%1" == "" goto migrate

goto error

:migrate
dotnet fm migrate -p SqlServer2014 -c "Server=.;Database=AqarPress;Integrated Security=True;" -a "F:\Projects\AqarPress-Git\Data\AqarPress.Migration\bin\Release\AqarPress.Migration.dll"
goto done

:rollback
migrate -db SqlServer2014 -connection "Server=.;Database=AqarPress;Integrated Security=True;" -assembly "AqarPress.Migration.dll" -task rollback:all
goto done

:error
echo "No valid command"

:done
echo "Completed"
