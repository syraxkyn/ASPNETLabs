const http = require('http');
const fs = require('fs');
const path = require('path');

const server = http.createServer((req, res) => {
  // Определяем путь к файлу HTML
  const filePath = path.join(__dirname, 'index.html');

  // Читаем содержимое файла HTML
  fs.readFile(filePath, 'utf8', (err, data) => {
    if (err) {
      // Если возникла ошибка, отправляем статус 500 (внутренняя ошибка сервера)
      res.writeHead(500, { 'Content-Type': 'text/plain' });
      res.end('Внутренняя ошибка сервера');
      return;
    }

    // Устанавливаем заголовок ответа
    res.writeHead(200, { 'Content-Type': 'text/html' });

    // Отправляем содержимое HTML-файла клиенту
    res.end(data);
  });
});

const port = 3000;

server.listen(port, () => {
  console.log(`Сервер запущен на порту ${port}`);
});
