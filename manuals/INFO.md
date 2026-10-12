## Переключаемся на контекст asu-10 (если слетел)
```docker context use asu-wsl```

## Запускаем контейнеры на asu-10
```docker compose up -d```

## Логи в рантайме
```docker compose logs -f```



## Что может пойти не так при перезагрузке:
Если /mnt/z пишет ```No such file or directory```: 
- Убедись, что машина asu-10 включена и доступна в сети. Если винда не сразу подцепила диск Z:, выполнить в WSL:

```Bash
sudo mount -a
```

## Если Docker ругается при docker compose up:
- Проверь, запущен ли SSH в WSL на машине asu-10 (если её перезагружали):

```Bash
ssh aza@10.0.4.37
```

## Если не подключается — на asu-10 нужно убедиться, что служба sudo service ssh start запущенa.