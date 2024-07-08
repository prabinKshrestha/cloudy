"use client";

import { Button, Card } from "flowbite-react";

export function AccountList() {
    return (
        <div className="w-full flex flex-col items-center">
            <Card className="w-3/4 max-w-2xl">
                <div className="flex flex-col gap-2">
                    <p className="text-xl font-bold text-gray-900 dark:text-white flex justify-between items-center">
                        Account name prabon
                        <span>
                            <svg className="w-[26px] h-[26px] text-red-700" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.8" d="M5 7h14m-9 3v8m4-8v8M10 3h4a1 1 0 0 1 1 1v3H9V4a1 1 0 0 1 1-1ZM6 7h12v13a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V7Z" />
                            </svg>
                        </span>
                    </p>
                    <p className="font-normal text-gray-700 dark:text-gray-400">
                        prabin2026@gmail.com
                    </p>
                    <Button className="mt-2">
                        File System
                    </Button>
                </div>
            </Card>
        </div>
    );
}
