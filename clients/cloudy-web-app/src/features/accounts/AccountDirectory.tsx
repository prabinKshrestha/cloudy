"use client";

import { useParams } from "react-router-dom";
import { HiHome, HiFolder, HiFolderAdd, HiTrash } from "react-icons/hi";
import { Breadcrumb } from "flowbite-react";
// import { useQuery } from "@tanstack/react-query";

const directories = [
    { id: 1, title: "Documents" },
    { id: 2, title: "Pictures" },
    { id: 3, title: "Music" },
];

// const fetchDirectories = async (id: string) => {
//     const response = await fetch(`https://localhost:7292/api/directories/${id}/children`);
//     if (!response.ok) {
//         throw new Error('Network response was not ok');
//     }
//     return response.json();
// };

const data: Array<{ id: string; name: string }> = [
    { id: "asdfsadf-asdfsadf23-2323-fadsf", name: "Prabin" },
    { id: "asdfsadf-asdfsadf23-2323-fadsf", name: "Prabin" },
    { id: "asdfsadf-asdfsadf23-2323-fadsf", name: "Prabin" },
    { id: "asdfsadf-asdfsadf23-2323-fadsf", name: "Prabin" },
    { id: "asdfsadf-asdfsadf23-2323-fadsf", name: "Prabin" },
];

export function AccountDirectory() {
    let { id } = useParams();

    // const { data, error, isLoading } = useQuery({
    //     queryKey: ['accounts'],
    //     queryFn: () => fetchDirectories(id!),
    // });

    // if (isLoading) return <p className="text-gray-900 dark:text-white">Loading...</p>;
    // if (error instanceof Error) return <p className="text-gray-900 dark:text-white">Error: {error.message}</p>;

    return (
        <div className="flex flex-col">
            <div className="pb-6 flex justify-between items-center">
                <div>
                    <Breadcrumb aria-label="Default breadcrumb example">
                        <Breadcrumb.Item href={`/accounts/${id}`} icon={HiHome}>
                            Home
                        </Breadcrumb.Item>
                        <Breadcrumb.Item href="#">Projects</Breadcrumb.Item>
                        <Breadcrumb.Item>Flowbite React</Breadcrumb.Item>
                    </Breadcrumb>
                </div>
                <div className="flex gap-3 items-center">
                    <HiTrash className="w-5 h-5 text-gray-500 dark:text-gray-500 p-0" title="Delete" />
                    <HiFolderAdd className="w-6 h-6 text-gray-500 dark:text-gray-500 p-0" title="Add Directory" />
                </div>
            </div>
            <div className="flex flex-wrap justify-start">
                {data?.map((dir: { id: string; name: string }) => (
                    <div
                        key={dir.id}
                        className="group/dir hover:bg-gray-100 hover:dark:bg-gray-800 w-24 h-24 flex flex-col items-center justify-center py-1 p-2 cursor-pointer overflow-hidden"
                    >
                        <HiFolder className="w-16 h-16 text-gray-500 dark:text-gray-600 p-0" />
                        <span className="text-sm text-gray-600 dark:text-gray-400">
                            {dir.name}
                        </span>
                    </div>
                ))
                }
            </div>
        </div>
    );
}
