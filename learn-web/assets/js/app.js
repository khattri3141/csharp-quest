// Renders the level map and handles unlock state.

function renderMap() {
  const root = document.getElementById('levelMap');
  if (!root) return;
  root.innerHTML = '';

  LEVELS.forEach(lvl => {
    const done = Progress.isComplete(lvl.id);
    const unlocked = Progress.isUnlocked(lvl.id);
    const ready = lvl.ready;

    const card = document.createElement('div');
    let cls = 'level-card';
    if (done) cls += ' done';
    else if (unlocked && ready) cls += ' current';
    else cls += ' locked';
    card.className = cls;

    const badge = done ? '&check;' : unlocked && ready ? lvl.id : '&#128274;';
    const status = !ready
      ? 'Coming soon'
      : done
      ? 'Complete'
      : unlocked
      ? 'Ready'
      : 'Locked';

    card.innerHTML = `
      <div class="level-num">Level ${String(lvl.id).padStart(2, '0')} &middot; ${status}</div>
      <div class="level-title">${lvl.title}</div>
      <div class="level-desc">${lvl.desc}</div>
      <div class="level-footer">
        <span class="level-xp">+${lvl.xp} XP</span>
        <div class="level-badge">${badge}</div>
      </div>
    `;

    card.addEventListener('click', () => {
      if (!ready) {
        toast('This level is coming soon.');
        return;
      }
      if (!unlocked && !Progress.teacherMode()) {
        toast('Finish the previous level to unlock this one.');
        return;
      }
      window.location.href = lvl.page;
    });

    root.appendChild(card);
  });

  updateHUD();
}

function updateHUD() {
  const xpFill = document.getElementById('xpFill');
  const xpValue = document.getElementById('xpValue');
  const badgeCount = document.getElementById('badgeCount');
  if (!xpFill) return;

  const current = Progress.totalXP();
  const max = Progress.maxXP();
  const pct = Math.min(100, (current / max) * 100);
  xpFill.style.width = pct + '%';
  xpValue.textContent = `${current} / ${max}`;
  badgeCount.textContent = Progress.load().completed.length;
}

function toast(msg) {
  const el = document.getElementById('toast');
  if (!el) return;
  el.textContent = msg;
  el.classList.add('show');
  setTimeout(() => el.classList.remove('show'), 2200);
}

function bindReset() {
  const btn = document.getElementById('resetBtn');
  if (!btn) return;
  btn.addEventListener('click', () => {
    if (confirm('Reset all progress? This cannot be undone.')) {
      Progress.reset();
      renderMap();
      toast('Progress reset.');
    }
  });
}

function applyTeacherModeBody() {
  document.body.classList.toggle('teacher-mode', Progress.teacherMode());
}

function bindTeacherToggle() {
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
  });
}

document.addEventListener('DOMContentLoaded', () => {
  renderMap();
  bindReset();
  bindTeacherToggle();
  applyTeacherModeBody();
});
