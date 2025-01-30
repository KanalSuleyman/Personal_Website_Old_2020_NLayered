class Counter {
    constructor(txtElement, number, start, wait = 2000) {
        this.txtElement = txtElement;
        this.number = number;
        this.txt = '';
        this.current = Number(start);
        this.numberIndex = 0;
        this.countSpeed = 1500 / (number - start);
        this.wait = parseInt(wait, 10);
        this.count();
    }


    count() {
        var text = String(this.current);

        this.txtElement.innerHTML = `${text}`;
        this.current++;

        if (this.current !== this.number) {
            setTimeout(() => this.count(), this.countSpeed);

        }
        else
            this.txtElement.innerHTML = String(this.number);

    }
}

document.addEventListener('DOMContentLoaded', init);

function init() {
    const txtElements = document.querySelectorAll('.entityCount');
    txtElements.forEach(startCounter);
}

function startCounter(txtElement) {
    const number = JSON.parse(txtElement.getAttribute('data-count'));
    const wait = txtElement.getAttribute('data-wait');
    var start = 0;
    new Counter(txtElement, number, start, wait);
}