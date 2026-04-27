echo "Имя пользователя: $USER"
echo "Имя Компьютера: $(hostname)"
echo "Системные каталоги:"
ls /
echo "Версия ядра Linux: $(uname -r)"
echo "Версия дистрибутива: $(nixos-version)"
# free -h | grep Mem
# echo "Диск: "
# df -h / | awk 'NR==2 {print "Занято: " $5 ", Свободно: " $4}'


echo "Локальное время: $(date)"
echo "Часовой пояс: $(cat /etc/timezone 2>/dev/null || timedatectl | grep 'Time zone')"
