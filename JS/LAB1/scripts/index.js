'use strict';

const tryParse = (str, min, max = Number.MAX_SAFE_INTEGER) => {
  let result = parseInt(str);
  if (!result) return false;
  return result >= min && result <= max;
};

const validateDate = (date) => {
  date = date.trim();
  if (date === '') return true;

  const values = date.split('.');
  if (values.length != 3) return false;

  const [day, month, year] = values;
  return tryParse(day, 1, 31) && tryParse(month, 1, 12) && tryParse(year, 1970);
};

const inputDate = (message) => {
  let input = prompt(message);

  while (input == null || !validateDate(input)) {
    alert('Дата введена некорректно');
    input = prompt(message);
  }

  if (input === '') return new Date();
  const [day, month, year] = input.split('.');
  return new Date(year, +month - 1, day);
};

const inputFormat = (message) => {
  const formats = ['годы', 'месяцы', 'недели', 'дни'];
  let format = prompt(message);

  while (!format || formats.indexOf(format.toLowerCase()) === -1) {
    alert('Формат введён некорректно');
    format = prompt(message);
  }

  return format;
};

const solution = () => {
  let first = inputDate('Введите первую дату в формате DD.MM.YYYY:');
  let second = inputDate('Введите вторую дату в формате DD.MM.YYYY:');

  if (first > second) [first, second] = [second, first];

  const totalDays = Math.floor(Math.abs(second - first) / (1000 * 3600 * 24));
  let format = inputFormat('Введите формат (годы, месяцы, недели, дни):');

  let years = 0,
    months = 0,
    days = 0;

  while (first <= second) {
    years++;
    first.setFullYear(first.getFullYear() + 1);
  }
  years--;
  first.setFullYear(first.getFullYear() - 1);

  while (first <= second) {
    months++;
    first.setMonth(first.getMonth() + 1);
  }
  months--;
  first.setMonth(first.getMonth() - 1);

  while (first <= second) {
    days++;
    first.setDate(first.getDate() + 1);
  }
  days--;

  switch (format) {
    case 'дни':
      alert(`Прошло ${totalDays} дней`);
      break;

    case 'недели':
      alert(`Прошло ${Math.floor(totalDays / 7)} недель ${totalDays % 7} дней`);
      break;

    case 'месяцы':
      alert(`Прошло\
        ${months + years * 12} месяцев\
        ${Math.floor(days / 7)} недель\
        ${days % 7} дней`);
      break;

    case 'годы':
      alert(`Прошло\
        ${years} лет\
        ${months} месяцев\
        ${Math.floor(days / 7)} недель\
        ${days % 7} дней`);
      break;
  }
};

solution();
