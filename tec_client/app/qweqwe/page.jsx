'use client'

import { useState } from "react"

export default function QwePage() { // Имя компонента с большой буквы
    const [val, setVal] = useState(0)

    // Функция-обработчик для кнопки
    const handleIncrement = () => {
        setVal((prev) => prev + 1)
    }

    const either = () => {
        console.log(document.cookie)
    }

    return (
        <>
            <p>Значение: {val}</p>
            {/* Вызываем функцию при клике */}
            <button onClick={handleIncrement}>inc</button>
            <button onClick={either}>Logs</button>
            <h1>Hello</h1>
        </>
    )
}