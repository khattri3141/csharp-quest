// Shared lesson-page logic: render quiz, validate answers, mark complete.

function applyTeacherModeBody() {
  document.body.classList.toggle('teacher-mode', Progress.teacherMode());
}

function bindTeacherToggle(onChange) {
  const btn = document.getElementById('teacherToggle');
  if (!btn) return;
  const refresh = () => {
    const on = Progress.teacherMode();
    btn.classList.toggle('on', on);
    btn.querySelector('.label').textContent = on ? 'Teacher: ON' : 'Teacher: OFF';
    applyTeacherModeBody();
  };
  refresh();
  btn.addEventListener('click', () => {
    Progress.setTeacherMode(!Progress.teacherMode());
    refresh();
    if (typeof onChange === 'function') onChange();
  });
}

function initLesson(config) {
  const { levelId, quiz } = config;
  bindTeacherToggle(() => {
    applyQuizVisibility();
    refreshCompleteButton();
  });
  applyTeacherModeBody();

  // Render quiz
  const quizRoot = document.getElementById('quizRoot');
  if (quizRoot && Array.isArray(quiz)) {
    quiz.forEach((q, qIdx) => {
      const qEl = document.createElement('div');
      qEl.className = 'quiz-q';
      qEl.innerHTML = `<div class="q-text">${qIdx + 1}. ${q.question}</div>`;
      const opts = document.createElement('div');
      opts.className = 'quiz-options';
      q.options.forEach((opt, oIdx) => {
        const id = `q${qIdx}_o${oIdx}`;
        const label = document.createElement('label');
        label.className = 'quiz-opt';
        label.dataset.qIdx = qIdx;
        label.dataset.oIdx = oIdx;
        label.innerHTML = `
          <input type="radio" name="q${qIdx}" id="${id}" value="${oIdx}" />
          <span>${opt}</span>
        `;
        opts.appendChild(label);
      });
      qEl.appendChild(opts);
      quizRoot.appendChild(qEl);
    });
  }

  const checkBtn = document.getElementById('checkQuizBtn');
  const completeBtn = document.getElementById('completeBtn');
  const statusEl = document.getElementById('quizStatus');
  const honorRow = document.getElementById('honorRow');
  const honorBox = document.getElementById('honorBox');

  let quizPassed = false;
  let honorChecked = false;

  function completeButtonLabel(teacher) {
    if (Progress.isComplete(levelId)) return 'Already Complete ✓';
    if (teacher) return 'Mark Level Complete (Teacher)';
    return 'Mark Level Complete';
  }

  function applyQuizVisibility() {
    const teacher = Progress.teacherMode();
    const display = teacher ? 'none' : '';
    [quizRoot, honorRow, checkBtn, statusEl].forEach(el => {
      if (el) el.style.display = display;
    });
    if (completeBtn) completeBtn.textContent = completeButtonLabel(teacher);
  }

  function refreshCompleteButton() {
    if (!completeBtn) return;
    if (Progress.isComplete(levelId)) {
      completeBtn.disabled = false;
      return;
    }
    if (Progress.teacherMode()) {
      completeBtn.disabled = false;
      return;
    }
    completeBtn.disabled = !(quizPassed && honorChecked);
  }

  if (honorBox && honorRow) {
    honorBox.addEventListener('change', () => {
      honorChecked = honorBox.checked;
      honorRow.classList.toggle('checked', honorChecked);
      refreshCompleteButton();
    });
  }

  if (checkBtn) {
    checkBtn.addEventListener('click', () => {
      let score = 0;
      quiz.forEach((q, qIdx) => {
        const sel = document.querySelector(`input[name="q${qIdx}"]:checked`);
        // Reset visuals
        document.querySelectorAll(`.quiz-opt[data-q-idx="${qIdx}"]`).forEach(o => {
          o.classList.remove('correct', 'wrong');
        });
        if (!sel) return;
        const chosen = Number(sel.value);
        const optEl = document.querySelector(`.quiz-opt[data-q-idx="${qIdx}"][data-o-idx="${chosen}"]`);
        if (chosen === q.answer) {
          score++;
          if (optEl) optEl.classList.add('correct');
        } else {
          if (optEl) optEl.classList.add('wrong');
          const correctEl = document.querySelector(`.quiz-opt[data-q-idx="${qIdx}"][data-o-idx="${q.answer}"]`);
          if (correctEl) correctEl.classList.add('correct');
        }
      });
      const total = quiz.length;
      Progress.recordQuiz(levelId, score);
      if (statusEl) {
        if (score === total) {
          statusEl.textContent = `Perfect! ${score} / ${total}. Confirm the console challenge below to finish this level.`;
          statusEl.className = 'quiz-status ok';
          quizPassed = true;
        } else {
          statusEl.textContent = `${score} / ${total}. Review and try again — you need all correct to unlock the next level.`;
          statusEl.className = 'quiz-status err';
          quizPassed = false;
        }
      }
      refreshCompleteButton();
    });
  }

  if (completeBtn) {
    applyQuizVisibility();
    refreshCompleteButton();
    completeBtn.addEventListener('click', () => {
      if (!Progress.isComplete(levelId) && !Progress.teacherMode() && !(quizPassed && honorChecked)) {
        if (statusEl) {
          statusEl.textContent = 'Pass the quiz AND confirm the console challenge first.';
          statusEl.className = 'quiz-status err';
        }
        return;
      }
      Progress.markComplete(levelId);
      celebrate();
      setTimeout(() => { window.location.href = '../index.html'; }, 1800);
    });
  }
}

function celebrate() {
  const colors = ['#7c5cff', '#22d3ee', '#22c55e', '#f59e0b', '#ef4444'];
  for (let i = 0; i < 80; i++) {
    const c = document.createElement('div');
    c.className = 'confetti';
    c.style.left = Math.random() * 100 + 'vw';
    c.style.background = colors[Math.floor(Math.random() * colors.length)];
    c.style.animationDelay = Math.random() * 0.6 + 's';
    c.style.transform = `rotate(${Math.random() * 360}deg)`;
    document.body.appendChild(c);
    setTimeout(() => c.remove(), 3000);
  }
}
