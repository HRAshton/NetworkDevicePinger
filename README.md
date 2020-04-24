# NetworkDevicePinger

**Problem**: a phone that is almost always on the same network as a PC can spontaneously
turn off, in which case the owner will miss important calls.

**Solution**: application in the tray, which once in 2.5 seconds checks whether the phone is connected to the network via ip.
If 5 attempts in succession fail, a message is displayed in the Windows notification panel.

## Instruction
1. Compile the project.
2. Record the ip-address of the device under test in ip.conf (make sure that ip is static).
3. Put in autorun.

## Additional features
- When you click on the tray icon displays the time and date of the last successful ping.
----

# NetworkDevicePinger

**Проблема**: телефон, почти всегда находящейся в одной сети с ПК, может спонтанно 
выключиться, в таком случае владелец пропустит важные звонки.

**Решение**: приложение в трее, которое раз в 2.5 секунды проверяет, в сети ли телефон по ip.
Если 5 попыток попыток подряд провалено, выводится сообщение в панели уведомлений Windows.

## Инструкция
1. Скомпилировать проект.
2. Записать в ip.conf ip-адрес проверяемого устройства (убедиться, что ip статический).
3. Поставить в автозапуск.

## Дополнительные возможности
- При клике на значок в трее отображает время и дату последнего успешного пинга.
