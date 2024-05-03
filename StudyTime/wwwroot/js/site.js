const ancor = Array.from(document.getElementsByTagName('a'));

ancor.forEach(a => {
    if (a.classList == null) {
        a.style.display == "none"
    }
});

const select_year = document.querySelector('.select-year');
const select_sep = document.querySelector('.select-specialty');

if (select_sep != null)
select_sep.addEventListener("click", () => {
    if (select_sep.value == "medical") {
        select_year.innerHTML = ` <select name="year" class="form-select select-year">
                    <option value="4">رابعة</option>
                    <option value="5">خامسة</option>
                </select > `;
    } else {
        select_year.innerHTML = ` <select name="year" class="form-select select-year">
                   <option value="1">اولى</option>
                    <option value="2">ثانية</option>
                    <option value="3">ثالثة</option>
                    <option value="4">رابعة</option>
                    <option value="5">خامسة</option>
                </select > `;
    }
});

