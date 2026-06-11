// Single source of truth for the curriculum.
// To add a new level: append here, drop a lessons/level-XX.html, scaffold the console folder.
const LEVELS = [
  {
    id: 1,
    title: 'Hello World',
    desc: 'Run your first C# program and print to the console.',
    xp: 100,
    page: 'lessons/level-01.html',
    consolePath: 'practice-console/Level01-HelloWorld/',
    ready: true,
  },
  {
    id: 2,
    title: 'Variables & Types',
    desc: 'Store data in int, string, bool, double — and pick the right one.',
    xp: 100,
    page: 'lessons/level-02.html',
    consolePath: 'practice-console/Level02-Variables/',
    ready: true,
  },
  {
    id: 3,
    title: 'Console I/O',
    desc: 'Read user input. Talk back to them. Convert text into numbers.',
    xp: 100,
    page: 'lessons/level-03.html',
    consolePath: 'practice-console/Level03-ConsoleIO/',
    ready: true,
  },
  {
    id: 4,
    title: 'If / Else',
    desc: 'Make decisions in code with conditions and branches.',
    xp: 100,
    page: 'lessons/level-04.html',
    consolePath: 'practice-console/Level04-IfElse/',
    ready: true,
  },
  {
    id: 5,
    title: 'Loops',
    desc: 'Repeat work without copy-paste. Beat the classic FizzBuzz.',
    xp: 100,
    page: 'lessons/level-05.html',
    consolePath: 'practice-console/Level05-Loops/',
    ready: true,
  },
  { id: 6, title: 'Methods', desc: 'Package code into reusable pieces.', xp: 100, ready: false },
  { id: 7, title: 'Arrays & List<T>', desc: 'Work with collections of values.', xp: 100, ready: false },
  { id: 8, title: 'Classes', desc: 'Your first taste of OOP.', xp: 100, ready: false },
  { id: 9, title: 'Properties', desc: 'Encapsulate state the C# way.', xp: 100, ready: false },
  { id: 10, title: 'Inheritance', desc: 'Build types on top of types.', xp: 100, ready: false },
  { id: 11, title: 'Exceptions', desc: 'Handle when things go wrong.', xp: 100, ready: false },
  { id: 12, title: 'Mini-Project', desc: 'Build a number guessing game.', xp: 100, ready: false },
];

const STORAGE_KEY = 'csharp-quest-progress-v1';

const TEACHER_KEY = 'csharp-quest-teacher-mode-v1';

const Progress = {
  load() {
    try {
      const raw = localStorage.getItem(STORAGE_KEY);
      if (!raw) return { completed: [], quizzes: {} };
      const data = JSON.parse(raw);
      return {
        completed: Array.isArray(data.completed) ? data.completed : [],
        quizzes: data.quizzes || {},
      };
    } catch {
      return { completed: [], quizzes: {} };
    }
  },
  teacherMode() {
    return localStorage.getItem(TEACHER_KEY) === '1';
  },
  setTeacherMode(on) {
    if (on) localStorage.setItem(TEACHER_KEY, '1');
    else localStorage.removeItem(TEACHER_KEY);
  },
  save(state) {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(state));
  },
  isComplete(levelId) {
    return this.load().completed.includes(levelId);
  },
  isUnlocked(levelId) {
    if (levelId === 1) return true;
    return this.isComplete(levelId - 1);
  },
  markComplete(levelId) {
    const state = this.load();
    if (!state.completed.includes(levelId)) {
      state.completed.push(levelId);
      this.save(state);
    }
  },
  recordQuiz(levelId, score) {
    const state = this.load();
    state.quizzes[levelId] = score;
    this.save(state);
  },
  totalXP() {
    const state = this.load();
    return state.completed.reduce((sum, id) => {
      const lvl = LEVELS.find(l => l.id === id);
      return sum + (lvl ? lvl.xp : 0);
    }, 0);
  },
  maxXP() {
    return LEVELS.reduce((sum, l) => sum + l.xp, 0);
  },
  reset() {
    localStorage.removeItem(STORAGE_KEY);
  },
};
