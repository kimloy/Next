export const convertTime12to24 = (time12h: string) => {
    const [time, modifier] = time12h.split(' ');

    let [hours, minutes] = time.split(':');
    let sHour;

    if (hours === '12') {
        hours = '00';
    }

    if (modifier === 'PM') {
        sHour = parseInt(hours, 10) + 12;
    }

    return `${sHour}${minutes}`;
}