#!/usr/bin/env bash

# Получаем реальный путь к файлу скрипта, даже если он вызван через symlink в /usr/local/bin
SOURCE="${BASH_SOURCE[0]}"
while [ -h "$SOURCE" ]; do
  DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
  SOURCE="$(readlink "$SOURCE")"
  [[ $SOURCE != /* ]] && SOURCE="$DIR/$SOURCE"
done
SCRIPT_DIR="$( cd -P "$( dirname "$SOURCE" )" && pwd )"

# Переходим в реальную папку проекта TEC
cd "$SCRIPT_DIR" || exit 1

COMPOSE_DEV="-f docker-compose.yml -f docker-compose.dev.yml"

case "$1" in
  dev)
    echo "🚀 Запуск DEV среды (Hot-Reload)..."
    docker compose $COMPOSE_DEV up
    ;;
  dev:build)
    echo "🔨 Пересборка и запуск DEV среды..."
    docker compose $COMPOSE_DEV up --build
    ;;
  dev:down)
    echo "🛑 Остановка DEV среды..."
    docker compose $COMPOSE_DEV down
    ;;
  prod)
    echo "🚀 Запуск PROD среды..."
    docker compose up -d --build
    ;;
  prod:down)
    echo "🛑 Остановка PROD среды..."
    docker compose down
    ;;
  logs)
    docker compose $COMPOSE_DEV logs -f ${2:-}
    ;;
  clean)
    docker system prune -f
    ;;
  *)
    echo "Использование: tec [dev|dev:build|dev:down|prod|prod:down|logs|clean]"
    exit 1
    ;;
esac
